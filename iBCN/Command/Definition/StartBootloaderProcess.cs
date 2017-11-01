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
    public class StartBootloaderProcess : BaseCommand, ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public StartBootloaderProcess()
        {
            Body = new byte[] { 0x07, 0x04 };
        }
    }
}
