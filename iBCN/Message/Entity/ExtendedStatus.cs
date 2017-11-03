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
    public class ExtendedStatus : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved1 { get; private set; } = new byte[32];

        /// <summary>
        /// 
        /// </summary>
        public byte[] Imei { get; private set; } = new byte[15];

        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved2 { get; private set; } = new byte[36];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
        }
    }
}
