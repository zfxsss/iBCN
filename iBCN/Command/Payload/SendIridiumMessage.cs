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
        public byte[] Message
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            if (Message == null)
            {
                return new byte[] { };
            }
            if (Message.Length > 240)
            {
                throw new Exception("");
            }

            return Message;
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x03, 0x30) };
    }
}
