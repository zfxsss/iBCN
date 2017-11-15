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

        private byte[] message;
        /// <summary>
        /// 
        /// </summary>
        public byte[] Message
        {
            get
            {
                return message;
            }
            set
            {
                if (value.Length != 1)
                {
                    throw new Exception("");
                }

                message = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return Message;
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x05, 0x20) };
    }
}
