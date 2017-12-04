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
    public class Identity : iBCNMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string ModelNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 SerialNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 FwRev_Major { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 FwRev_Minor { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 FwRev_Revision { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string IridiumFwRev { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string GpsFwRev { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            ModelNumber = Encoding.ASCII.GetString(entityData.Take(24).ToArray()).TrimEnd('\0');
            SerialNumber = BitConverter.ToUInt32(entityData.Skip(24).Take(4).Reverse().ToArray(), 0);
            FwRev_Major = entityData.Skip(28).Take(1).ToArray()[0];
            FwRev_Minor = entityData.Skip(29).Take(1).ToArray()[0];
            FwRev_Revision = BitConverter.ToUInt16(entityData.Skip(30).Take(2).Reverse().ToArray(), 0);
            IridiumFwRev = Encoding.ASCII.GetString(entityData.Skip(32).Take(16).ToArray()).TrimEnd('\0');
            GpsFwRev = Encoding.ASCII.GetString(entityData.Skip(48).Take(80).ToArray()).TrimEnd('\0');
        }
    }
}
