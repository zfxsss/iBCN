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
    public class ExtendedStatus : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved1 { get; set; } = new byte[32];

        /// <summary>
        /// 
        /// </summary>
        public byte[] Imei { get; set; } = new byte[15];

        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved2 { get; set; } = new byte[36];

        /// <summary>
        /// 
        /// </summary>
        public ExtendedStatus() : base("ExtendedStatus")
        {

        }
    }
}
