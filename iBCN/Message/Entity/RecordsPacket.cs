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
    public class RecordsPacket : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 RecordIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EventReport> Records { get; set; } = new List<EventReport>(12);
    }
}
