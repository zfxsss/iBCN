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
    public class BasePayload : IPayload
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual byte[] ToBytes()
        {
            //to be implemented
            return null;
        }
    }
}
