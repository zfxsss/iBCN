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
    public class RequestPositionReport_Last : ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RequestPositionReport_Last()
        {
            Body = new byte[] { 0x03, 0x10 };
        }
    }
}
