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
        public UInt32 Latitude { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 Longitude { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 Speed { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 FixAccuracy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 NumSatellites { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtData"></param>
        public override void FromBytes(byte[] evtData)
        {
            base.FromBytes(evtData);
            Latitude = BitConverter.ToUInt32(evtData.Take(4).Reverse().ToArray(), 0);
            Longitude = BitConverter.ToUInt32(evtData.Skip(4).Take(4).Reverse().ToArray(), 0);
            Speed = evtData.Skip(8).Take(1).ToArray()[0];
            FixAccuracy = evtData.Skip(9).Take(1).ToArray()[0];
            NumSatellites = evtData.Skip(10).Take(1).ToArray()[0];
        }
    }
}
