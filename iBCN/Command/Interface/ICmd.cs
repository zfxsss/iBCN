using Metocean.iBCN.Command.Payload.Interface;
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
        UInt16 CmdTypeCode { get; }

        /// <summary>
        /// 
        /// </summary>
        UInt16 SubCmdTypeCode { get; }

        /// <summary>
        /// 
        /// </summary>
        UInt16 Sequence { get; }

        /// <summary>
        /// 
        /// </summary>
        IPayload Payload { get; }
    }
}
