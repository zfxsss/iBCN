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
    public class Status : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 BatteryVoltage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Temperature { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Reserved1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte GpsStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved2 { get; set; } = new byte[4];

        /// <summary>
        /// 
        /// </summary>
        public Status() : base()
        {

        }
    }
}
