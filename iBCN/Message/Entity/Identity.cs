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
    public class Identity : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] ModelNumber { get; private set; } = new byte[24];

        /// <summary>
        /// 
        /// </summary>
        public UInt32 SerialNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] FwRev { get; private set; } = new byte[4];

        /// <summary>
        /// 
        /// </summary>
        public byte[] IridiumFwRev { get; private set; } = new byte[16];

        /// <summary>
        /// 
        /// </summary>
        public byte[] GpsFwRev { get; private set; } = new byte[80];

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
