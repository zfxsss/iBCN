using Metocean.iBCN.Message.Entity.EventData.Interface;
using Metocean.iBCN.Message.Interface.Parser;
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
    public class PowerUp : BaseEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte ResetReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtCode"></param>
        public PowerUp()
        {

        }
    }
}
