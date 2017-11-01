using Metocean.iBCN.Message.Entity.Interface;
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
    public class DateTime : BaseMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date_Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime()
        {

        }
    }
}
