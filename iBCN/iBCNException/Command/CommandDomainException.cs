using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException.Command
{
    public class CommandDomainException : ApplicationException
    {
        public CommandDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
