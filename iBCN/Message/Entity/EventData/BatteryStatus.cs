using Metocean.iBCN.Message.Entity.EventData.Interface;
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
    public class BatteryStatus : BaseEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt16 Voltage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Temperature { get; set; }

    }
}
