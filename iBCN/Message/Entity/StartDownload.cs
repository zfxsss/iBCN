using Metocean.iBCN.Message.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class StartDownload : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Acknowledgement Ack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 StartIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 EndIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StartDownload() : base("StartDownload")
        {
        }
    }
}
