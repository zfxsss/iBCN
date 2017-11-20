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
    public class InvalidDebugLevel : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public InvalidDebugLevel(string msg) : base(msg) { }
    }
}
