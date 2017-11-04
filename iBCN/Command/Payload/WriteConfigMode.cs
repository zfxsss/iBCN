using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Message.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Payload
{
    /// <summary>
    /// 
    /// </summary>
    public class WriteConfigMode : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Mode Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { };
    }
}
