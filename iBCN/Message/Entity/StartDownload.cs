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
    public class StartDownload : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public Acknowledgement Ack { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 StartIndex { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 EndIndex { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Ack = new Acknowledgement();
            Ack.FromBytes(entityData.Take(1).ToArray());
            StartIndex = BitConverter.ToUInt32(entityData.Skip(1).Take(4).Reverse().ToArray(), 0);
            EndIndex = BitConverter.ToUInt32(entityData.Skip(5).Take(4).Reverse().ToArray(), 0);
        }
    }
}
