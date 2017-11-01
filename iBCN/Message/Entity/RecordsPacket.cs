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
    public class RecordsPacket : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 RecordIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EventReport[] Records { get; set; } = new EventReport[12];

        /// <summary>
        /// 
        /// </summary>
        public RecordsPacket()
        {

        }
    }
}
