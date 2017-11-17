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
        public UInt16 Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Mode[] Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            var bytes = new byte[] { };
            if (Index != 0xFF)
            {
                bytes = bytes.Concat(new byte[] { BitConverter.GetBytes(Index)[0] }).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].Reserved1).Reverse()).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].FixInterval).Reverse()).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].Reserved2).Reverse()).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].MailboxCheckInterval).Reverse()).ToArray();
                bytes = bytes.Concat(new byte[] { BitConverter.GetBytes(Mode[0].SurfacingSetting)[0] }).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].TransmitIntervalFlags).Reverse()).ToArray();
                bytes = bytes.Concat(BitConverter.GetBytes(Mode[0].TransmitInterval).Reverse()).ToArray();
            }
            else
            {
                bytes = bytes.Concat(new byte[] { BitConverter.GetBytes(Index)[0] }).ToArray();
                for (UInt16 i = 0; i < Mode.Length; i++)
                {
                    //bytes = bytes.Concat(new byte[] { BitConverter.GetBytes(i)[0] }).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].Reserved1).Reverse()).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].FixInterval).Reverse()).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].Reserved2).Reverse()).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].MailboxCheckInterval).Reverse()).ToArray();
                    bytes = bytes.Concat(new byte[] { BitConverter.GetBytes(Mode[i].SurfacingSetting)[0] }).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].TransmitIntervalFlags).Reverse()).ToArray();
                    bytes = bytes.Concat(BitConverter.GetBytes(Mode[i].TransmitInterval).Reverse()).ToArray();
                }
            }
            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x05, 0x11) };
    }
}
