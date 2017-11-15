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
                if (!(debugLevel >= 0 && debugLevel <= 3))
                {
                    throw new Exception("");
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
