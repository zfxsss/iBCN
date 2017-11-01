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
    public class DateTime : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date_Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime() : base()
        {

        }
    }
}
