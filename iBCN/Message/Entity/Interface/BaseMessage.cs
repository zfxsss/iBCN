using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseMessage : IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void FromBytes(byte[] entityData)
        {
            throw new NotImplementedException("");
        }
    }
}
