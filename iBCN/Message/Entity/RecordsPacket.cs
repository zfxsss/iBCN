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
    public class RecordsPacket : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 RecordIndex { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public EventReport[] Records { get; private set; } = new EventReport[12];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            RecordIndex = BitConverter.ToUInt32(entityData.Take(4).Reverse().ToArray(), 0);
            for (int i = 0; i < Records.Length; i++)
            {
                Records[i] = new EventReport();
                Records[i].FromBytes(entityData.Skip(i * 16 + 4).Take(16).ToArray());
            }
        }
    }
}
