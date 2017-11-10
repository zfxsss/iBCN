using iBCNLinkLayer.Link;
using iBCNLinkLayer.Link.Interface;
using iBCNLinkLayer.LinkRepository;
using iBCNLinkLayer.MsgQueue;
using iBCNLinkLayer.MsgQueue.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace iBCNLinkLayer.MsgQueueEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        private static iBCNLinkRepo linkRepo = new iBCNLinkRepo();

        /// <summary>
        /// 
        /// </summary>
        private static IMsgQueue msgQueue = new MessageQueue();

        /// <summary>
        /// 
        /// </summary>
        private static CancellationTokenSource ctSrc;

        /// <summary>
        /// 
        /// </summary>
        private static int workerNumberInBound = 0;

        /// <summary>
        /// 
        /// </summary>
        private static object workerNumberInBoundLock = new object();

        /// <summary>
        /// 
        /// </summary>
        private static int workerNumberOutBound = 0;

        /// <summary>
        /// 
        /// </summary>
        private static object workerNumberOutBoundLock = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        /// <returns></returns>
        public static ILink BuildOrGetLink(LinkDescription linkDescription)
        {
            return linkRepo[linkDescription];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        public static void RemoveLink(LinkDescription linkDescription)
        {
            linkRepo.RemoveItem(linkDescription);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qi"></param>
        public static void EnqueInBoundMsg(QueueItem qi)
        {
            msgQueue.InBoundQueue.Add(qi);
            msgQueue.InBoundQueue.CompleteAdding();

            TakeItemFromInBound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="qi"></param>
        public static void EnqueOutBoundMsg(QueueItem qi)
        {
            msgQueue.OutBoundQueue.Add(qi);
            msgQueue.OutBoundQueue.CompleteAdding();

            TakeItemFromOutBound();
        }

        /// <summary>
        /// 
        /// </summary>
        private static Action<BlockingCollection<QueueItem>, object, int> dequeAction = (bc, lck, number) =>
        {
            lock (lck)
            {
                if (number == 0)
                {
                    ctSrc = new CancellationTokenSource();
                    number++;
                    var ct = ctSrc.Token;
                    Task.Run(() =>
                    {
                        while (!ct.IsCancellationRequested)
                        {
                            var qi = bc.Take(ct);
                            if ((qi.Message != null) && (qi.ItemAction != null))
                            {
                                qi.ItemAction(qi.Message);
                            }
                        }
                    }, ct)
                    .ContinueWith(e =>
                    {
                        lock (lck)
                        {
                            number--;
                        }

                        var exception = e.Exception;
                        if (exception.InnerException is OperationCanceledException)
                        {

                        }
                        else
                        {
                            throw exception.InnerException;
                        }
                    });

                }
            }
        };

        /// <summary>
        /// 
        /// </summary>
        private static void TakeItemFromInBound()
        {
            dequeAction(msgQueue.InBoundQueue, workerNumberInBoundLock, workerNumberInBound);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void TakeItemFromOutBound()
        {
            dequeAction(msgQueue.OutBoundQueue, workerNumberOutBoundLock, workerNumberOutBound);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            ctSrc.Cancel();
            ctSrc.Dispose();
        }

    }
}
