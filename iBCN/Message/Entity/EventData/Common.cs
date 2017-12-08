using Metocean.iBCN.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    public class Common : iBCNEvtData, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Evt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtData"></param>
        public override void FromBytes(byte[] evtData)
        {
            base.FromBytes(evtData);
            Evt = evtData;
        }

    }
}
