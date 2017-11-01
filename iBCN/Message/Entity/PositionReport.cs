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
    public class PositionReport : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte EventCode { get; set; }

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
        public byte TimeToFix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PositionReport() : base()
        {

        }
    }
}
