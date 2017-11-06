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
    public class LinkDataBuffer
    {
        /// <summary>
        /// 
        /// </summary>
        public BlockingCollection<ConcurrentQueue<byte[]>> InBoundQueue { get; } = new BlockingCollection<ConcurrentQueue<byte[]>>(1000);

        /// <summary>
        /// 
        /// </summary>
        public BlockingCollection<ConcurrentQueue<byte[]>> OutBoundQueue { get; } = new BlockingCollection<ConcurrentQueue<byte[]>>(1000);

    }
}
