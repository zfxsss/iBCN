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
    public class Status : iBCNMessage, IMsgEntity
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
        public byte[] Reserved2 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Time = new DateTime();
            Time.FromBytes(entityData.Take(4).ToArray());
            BatteryVoltage = BitConverter.ToUInt16(entityData.Skip(4).Take(2).Reverse().ToArray(), 0);
            Temperature = entityData[6];
            Reserved1 = entityData[7];
            GpsStatus = entityData[8];
            Reserved2 = entityData.Skip(9).Take(4).ToArray();
        }
    }
}
