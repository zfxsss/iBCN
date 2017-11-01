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
        public UInt32 RecordCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 LastRecordDownloaded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FirstRecordTimestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastRecordTimestamp { get; set; }

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
