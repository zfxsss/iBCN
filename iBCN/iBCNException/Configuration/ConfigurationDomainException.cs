using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationDomainException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ConfigurationDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
