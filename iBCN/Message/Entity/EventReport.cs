using Metocean.iBCN.Message.Entity.EventData;
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
    public class EventReport : iBCNMessage, IParser
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
        public iBCNEvtData EventData { get; set; }
        //byte[] EventData { get; set; } = new byte[11];

        /// <summary>
        /// 
        /// </summary>
        public EventReport() : base()
        {

        }
    }
}
