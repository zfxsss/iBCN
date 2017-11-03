using Metocean.iBCN.Command.Payload.Interface;
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
    public class SendIridiumMessage : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Message { get; set; } = new byte[] { };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return null;
        }
    }
}
