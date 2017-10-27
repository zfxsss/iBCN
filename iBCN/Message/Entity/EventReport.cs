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
    public class EventReport : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        byte EventCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        byte[] EventData { get; set; } = new byte[11];

        /// <summary>
        /// 
        /// </summary>
        public EventReport() : base()
        {

        }
    }
}
