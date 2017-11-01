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
    public class GpsTimeout : iBCNEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Speed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte FixAccuracy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte NumSatellites { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtData"></param>
        public override void FromBytes(byte[] evtData)
        {
            base.FromBytes(evtData);
        }
    }
}
