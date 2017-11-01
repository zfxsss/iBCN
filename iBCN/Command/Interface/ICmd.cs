using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICmd
    {
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
