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
    public class LogStatus : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 RecordCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 LastRecordDownloaded { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FirstRecordTimestamp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastRecordTimestamp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            RecordCount = BitConverter.ToUInt32(entityData.Take(4).Reverse().ToArray(), 0);
            LastRecordDownloaded = BitConverter.ToUInt32(entityData.Skip(4).Take(4).Reverse().ToArray(), 0);
            FirstRecordTimestamp = new DateTime();
            FirstRecordTimestamp.FromBytes(entityData.Skip(8).Take(4).ToArray());
            LastRecordTimestamp = new DateTime();
            LastRecordTimestamp.FromBytes(entityData.Skip(12).Take(4).ToArray());
        }
    }
}
