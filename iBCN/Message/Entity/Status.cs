using Metocean.iBCN.Message.Interface.Parser;
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
    public class Status : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 BatteryVoltage { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Temperature { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Reserved1 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte GpsStatus { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved2 { get; private set; } = new byte[4];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
        }
    }
}
