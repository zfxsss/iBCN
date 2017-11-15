using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Acknowledgement : iBCNMessage, IParser
    {
        /// <summary>
        /// true: Success, false: Error
        /// </summary>
        public bool Ack { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            if (entityData[0] == 0)
            {
                Ack = true;
            }
            else
            {
                Ack = false;
            }
        }
    }
}
