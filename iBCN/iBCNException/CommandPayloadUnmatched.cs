using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException
{
    /// <summary>
    /// 
    /// </summary>
    class CommandPayloadUnmatched : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public CommandPayloadUnmatched(string msg) : base(msg) { }
    }
}
