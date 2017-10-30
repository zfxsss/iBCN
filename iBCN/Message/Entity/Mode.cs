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
    public class Mode : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 Reserved1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 FixInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 Reserved2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 MailboxCheckInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte SurfacingSetting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitIntervalFlags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Mode() : base("Mode")
        {

        }
    }
}
