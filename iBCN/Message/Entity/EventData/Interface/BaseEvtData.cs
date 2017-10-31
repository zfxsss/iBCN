using Metocean.iBCN.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseEvtData : PropertyAccessor, IEvtData
    {
        /// <summary>
        /// 
        /// </summary>
        public int EventCode { get; set; }
    }
}
