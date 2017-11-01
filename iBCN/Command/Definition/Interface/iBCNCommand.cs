using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Definition.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class iBCNCommand : ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasPayload
        {
            get
            {
                return false;
            }
        }

    }
}
