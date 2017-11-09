using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.MsgQueue.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMsgQueue
    {
        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<ConcurrentQueue<QueueItem>> InBoundQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<ConcurrentQueue<QueueItem>> OutBoundQueue { get; }
    }
}
