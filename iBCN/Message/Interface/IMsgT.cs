using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMsg<T> : IMsg
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        T ParseBytes(byte[] entityData);

        /// <summary>
        /// 
        /// </summary>
        T MessageEntity { get; }
    }
}
