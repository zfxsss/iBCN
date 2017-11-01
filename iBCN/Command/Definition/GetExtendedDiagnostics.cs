using Metocean.iBCN.Command.Definition.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Definition
{
    /// <summary>
    /// 
    /// </summary>
    public class GetExtendedDiagnostics : iBCNCommand, ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public GetExtendedDiagnostics()
        {
            Body = new byte[] { 0x03, 0x04 };
        }
    }
}
