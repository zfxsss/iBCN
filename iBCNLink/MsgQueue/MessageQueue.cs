using iBCNLinkLayer.MsgQueue.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.MsgQueue
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageQueue : IMsgQueue
    {
        /// <summary>
        /// 
        /// </summary>
        const int MaxSize = 8192;

        /// <summary>
        /// 
        /// </summary>
        public BlockingCollection<ConcurrentQueue<QueueItem>> InBoundQueue { get; } = new BlockingCollection<ConcurrentQueue<QueueItem>>(MaxSize);

        /// <summary>
        /// 
        /// </summary>
        public BlockingCollection<ConcurrentQueue<QueueItem>> OutBoundQueue { get; } = new BlockingCollection<ConcurrentQueue<QueueItem>>(MaxSize);
    }
}
