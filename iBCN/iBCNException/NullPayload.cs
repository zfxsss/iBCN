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
    public class NullPayload : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public NullPayload(string msg) : base(msg) { }
    }
}
