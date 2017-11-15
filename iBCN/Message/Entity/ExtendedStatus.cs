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
        public byte[] Reserved1 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Imei { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Reserved2 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Reserved1 = entityData.Take(32).ToArray();
            Imei = Encoding.ASCII.GetString(entityData.Skip(32).Take(15).ToArray()).TrimEnd('\0');
            Reserved2 = entityData.Skip(47).Take(36).ToArray();
        }
    }
}
