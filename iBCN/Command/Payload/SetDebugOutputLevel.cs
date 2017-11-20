using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.iBCNException;
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
    public class SetDebugOutputLevel : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        private UInt16 debugLevel;

        /// <summary>
        /// 
        /// </summary>
        public UInt16 DebugLevel
        {
            get
            {
                return debugLevel;
            }
            set
            {
                if (!(value >= 0 && value <= 3))
                {
                    throw new InvalidDebugLevel("debug level is not between 0 and 3: " + value.ToString());
                }

                debugLevel = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { BitConverter.GetBytes(DebugLevel)[0] };
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x05, 0x20) };
    }
}
