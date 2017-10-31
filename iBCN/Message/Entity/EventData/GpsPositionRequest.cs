using Metocean.iBCN.Message.Entity.EventData.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    /// <summary>
    /// 
    /// </summary>
    public class GpsPositionRequest : BaseEvtData, IEvtData
    {
        /// <summary>
        /// 
        /// </summary>
        public byte Source { get; set; }
    }
}
