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
    public interface ICmd
    {
        /// <summary>
        /// 
        /// </summary>
        Type CmdType { get; }

        /// <summary>
        /// 
        /// </summary>
        int CmdTypeCode { get; }

        /// <summary>
        /// 
        /// </summary>
        int SubCmdTypeCode { get; }
    }
}
