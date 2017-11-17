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
        public EventReport[] Records { get; private set; } = new EventReport[] { };

        /// <summary>
        /// 
        /// </summary>
        public bool isComplete { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            isComplete = (entityData[0] & 0x80) == 0x80 ? true : false;
            entityData[0] = (byte)(0x7F & entityData[0]);
            RecordIndex = BitConverter.ToUInt32(entityData.Take(4).Reverse().ToArray(), 0);
            var count = (entityData.Length - 4) / 16;
            for (int i = 0; i < count; i++)
            {
                var report = new EventReport();
                report.FromBytes(entityData.Skip(i * 16 + 4).Take(16).ToArray());
                Records = Records.Concat(new EventReport[] { report }).ToArray();
            }
        }
    }
}
