using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Payload.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();

        /// <summary>
        /// 
        /// </summary>
        Tuple<uint, uint>[] CommandsSupported { get; }
    }
}
