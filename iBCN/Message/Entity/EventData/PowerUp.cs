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
    public class PowerUp : iBCNEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte ResetReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtData"></param>
        public override void FromBytes(byte[] evtData)
        {
            base.FromBytes(evtData);
        }
    }
}
