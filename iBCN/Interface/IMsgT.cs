using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMsg<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        T ParseBytes(byte[] data);
    }
}
