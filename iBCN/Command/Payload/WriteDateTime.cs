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
    public class WriteDateTime : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date_Time { get; set; }

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
