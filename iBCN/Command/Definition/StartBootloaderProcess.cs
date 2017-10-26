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
    public class StartBootloaderProcess : ICmdDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Body
        {
            get
            {
                return new byte[] { 0x07, 0x04 };
            }
        }
    }
}
