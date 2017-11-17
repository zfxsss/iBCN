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
    public class ReadConfigMode : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt16 Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { BitConverter.GetBytes(Index)[0] };
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x05, 0x01) };
    }
}
