using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    /// <summary>
    /// 
    /// </summary>
    public class BatteryStatus : iBCNEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt16 Voltage { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Int16 Temperature { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtData"></param>
        public override void FromBytes(byte[] evtData)
        {
            base.FromBytes(evtData);
            Voltage = BitConverter.ToUInt16(evtData.Take(2).Reverse().ToArray(), 0);
            Temperature = (sbyte)(evtData.Skip(2).Take(1).ToArray()[0]);
        }

    }
}
