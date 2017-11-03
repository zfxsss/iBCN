using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException.Message
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageDomainException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MessageDomainException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MessageDomainException(string message) : base(message) { }
    }
}
