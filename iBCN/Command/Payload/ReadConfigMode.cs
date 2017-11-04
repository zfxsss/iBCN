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
        public int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return null;

            //CommandsSupported.Count(x => x.Item1 == 1 && x.Item2 == 2);
        }

        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { };
    }
}
