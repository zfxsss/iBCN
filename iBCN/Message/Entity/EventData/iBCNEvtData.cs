using Metocean.iBCN.iBCNException;
using Metocean.iBCN.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    /// <summary>
    /// Base class for event data
    /// </summary>
    public abstract class iBCNEvtData : IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void FromBytes(byte[] evtData)
        {
            if (evtData.Length != 11)
            {
                throw new InvalidBytesLength("The length of the byte stream for the event data is invalid: " + evtData.Length.ToString());
            }
        }
    }
}
