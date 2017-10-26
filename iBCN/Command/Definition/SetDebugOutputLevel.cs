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
    public class SetDebugOutputLevel : ICmdDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Body
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public SetDebugOutputLevel()
        {
            //1 byte payload
            Body = new byte[] { 0x05, 0x20 };
        }
    }
}
