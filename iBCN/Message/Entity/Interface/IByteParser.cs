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
    public interface IBytesParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void ParseBytes(byte[] data);
    }
}
