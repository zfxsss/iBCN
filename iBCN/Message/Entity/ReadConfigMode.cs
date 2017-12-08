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
    public class ReadConfigMode : iBCNMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt16 Index { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Mode[] Mode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            if (entityData.Length == 18)
            {
                Index = entityData[0];
                Mode = new Mode[1];
                Mode[0] = new Mode();
                Mode[0].FromBytes(entityData.Skip(1).Take(17).ToArray());
            }
            else
            {
                Index = 0xFF;
                Mode = new Mode[10];
                for (int i = 0; i < Mode.Length; i++)
                {
                    Mode[i] = new Mode();
                    Mode[i].FromBytes(entityData.Skip(18 * i + 1).Take(17).ToArray());
                }
            }
        }
    }
}
