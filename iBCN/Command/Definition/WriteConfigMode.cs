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
    public class WriteConfigMode : ICmdBytes
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
        public WriteConfigMode()
        {
            //1 byte payload
            Body = new byte[] { 0x05, 0x11 };
        }
    }
}
