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
    public class GetIdentification : ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public Byte[] Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GetIdentification()
        {
            Body = new byte[] { 0x03, 0x01 };
        }
    }
}
