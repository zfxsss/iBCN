using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Interface.Parser
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// 
        /// </summary>
        void FromBytes(byte[] bytes);
    }
}
