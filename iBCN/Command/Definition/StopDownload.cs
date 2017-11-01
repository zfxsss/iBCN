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
    public class StopDownload : iBCNCommand, ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public StopDownload()
        {
            Body = new byte[] { 0x09, 0x20 };
        }
    }
}
