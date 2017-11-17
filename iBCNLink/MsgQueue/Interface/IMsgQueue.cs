using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCNLinkLayer.MsgQueue.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMsgQueue
    {
        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<QueueItem> InBoundQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<QueueItem> OutBoundQueue { get; }
    }
}
