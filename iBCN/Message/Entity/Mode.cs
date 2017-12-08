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
    public class Mode : iBCNMessage, IMsgEntity
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
        public UInt16 SurfacingSetting { get; private set; }

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
            Reserved1 = BitConverter.ToUInt32(entityData.Take(4).Reverse().ToArray(), 0);
            FixInterval = BitConverter.ToUInt32(entityData.Skip(4).Take(4).Reverse().ToArray(), 0);
            Reserved2 = BitConverter.ToUInt16(entityData.Skip(8).Take(2).Reverse().ToArray(), 0);
            MailboxCheckInterval = BitConverter.ToUInt16(entityData.Skip(10).Take(2).Reverse().ToArray(), 0);
            SurfacingSetting = entityData[12];
            TransmitIntervalFlags = BitConverter.ToUInt16(entityData.Skip(13).Take(2).Reverse().ToArray(), 0);
            TransmitInterval = BitConverter.ToUInt16(entityData.Skip(15).Take(2).Reverse().ToArray(), 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserved1"></param>
        /// <param name="fixInterval"></param>
        /// <param name="reserved2"></param>
        /// <param name="mailboxCheckInterval"></param>
        /// <param name="surfaceSetting"></param>
        /// <param name="transmitIntervalFlags"></param>
        /// <param name="transmitInterval"></param>
        public Mode(UInt32 reserved1, UInt32 fixInterval, UInt16 reserved2, UInt16 mailboxCheckInterval, UInt16 surfaceSetting, UInt16 transmitIntervalFlags, UInt16 transmitInterval)
        {
            Reserved1 = reserved1;
            FixInterval = fixInterval;
            Reserved2 = reserved2;
            MailboxCheckInterval = mailboxCheckInterval;
            SurfacingSetting = surfaceSetting;
            TransmitIntervalFlags = transmitIntervalFlags;
            TransmitInterval = transmitInterval;
        }

        /// <summary>
        /// 
        /// </summary>
        public Mode()
        {

        }
    }
}
