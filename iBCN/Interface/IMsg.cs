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
    public interface IMsg
    {
        /// <summary>
        /// 
        /// </summary>
        Type MsgType { get; }
    }
}
