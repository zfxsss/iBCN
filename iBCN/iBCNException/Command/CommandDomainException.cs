using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandDomainException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CommandDomainException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public CommandDomainException(string message) : base(message) { }
    }
}
