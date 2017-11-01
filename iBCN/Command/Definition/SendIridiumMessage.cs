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
    public class SendIridiumMessage : BaseCommand, ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public SendIridiumMessage()
        {
            //up to 240 bytes payload
            Body = new byte[] { 0x03, 0x30 };
        }
    }
}
