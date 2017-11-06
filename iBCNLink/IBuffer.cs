using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace iBCNLink
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBuffer
    {
        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<ConcurrentQueue<byte[]>> InBoundQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        void Enque(byte[] bytes);

        /// <summary>
        /// 
        /// </summary>
        BlockingCollection<ConcurrentQueue<byte[]>> OutBoundQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte[] Deque();
    }
}
