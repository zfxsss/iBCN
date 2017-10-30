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
    /// <typeparam name="T"></typeparam>
    interface ICmd<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        T AppendBytes(object payload);

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
