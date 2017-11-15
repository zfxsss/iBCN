using Metocean.iBCN.Message.Entity.EventData;
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
    public class Position : iBCNEvtData, IParser
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
        public UInt16 TimeToFix { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Latitude = BitConverter.ToUInt32(entityData.Take(4).Reverse().ToArray(), 0);
            Longitude = BitConverter.ToUInt32(entityData.Skip(4).Take(4).Reverse().ToArray(), 0);
            Speed = entityData.Skip(8).Take(1).ToArray()[0];
            FixAccuracy = entityData.Skip(9).Take(1).ToArray()[0];
            TimeToFix = entityData.Skip(10).Take(1).ToArray()[0];
        }
    }
}
