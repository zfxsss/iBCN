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
    public class Mode : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 Reserved1 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 FixInterval { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 Reserved2 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 MailboxCheckInterval { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte SurfacingSetting { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitIntervalFlags { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitInterval { get; private set; }

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
