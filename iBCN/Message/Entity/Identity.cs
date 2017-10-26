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
    public class Identity : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] ModelNumber { get; set; } = new byte[24];

        /// <summary>
        /// 
        /// </summary>
        public UInt32 SerialNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] FwRev { get; set; } = new byte[4];

        /// <summary>
        /// 
        /// </summary>
        public byte[] IridiumFwRev { get; set; } = new byte[16];

        /// <summary>
        /// 
        /// </summary>
        public byte[] GpsFwRev { get; set; } = new byte[80];
    }
}
