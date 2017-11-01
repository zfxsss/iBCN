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
    public class ReadDateTime : BaseCommand, ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public ReadDateTime()
        {
            Body = new byte[] { 0x03, 0x20 };
        }
    }
}
