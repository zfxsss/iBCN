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
    public abstract class iBCNMessage : IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void FromBytes(byte[] entityData)
        {
            if (GetType() == typeof(DateTime))
            {
                if (entityData.Length != 4)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(Acknowledgement))
            {
                if (entityData.Length != 1)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(Status))
            {
                if (entityData.Length != 13)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(LogStatus))
            {
                if (entityData.Length != 16)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(Identity))
            {
                if (entityData.Length != 128)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(ExtendedStatus))
            {
                if (entityData.Length != 83)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(EventReport))
            {
                if (entityData.Length != 16)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(Mode))
            {
                if (entityData.Length != 17)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(ReadConfigMode))
            {
                if (!((entityData.Length == 18) || (entityData.Length == 180)))
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(RecordsPacket))
            {
                if ((entityData.Length > 16 * 12 + 4) || (entityData.Length % 16 != 4))
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(StartDownload))
            {
                if (entityData.Length != 9)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(ReceiveIridiumMessage))
            {
                if (entityData.Length > 240)
                {
                    throw new Exception("");
                }
            }
            else if (GetType() == typeof(MultiplePositionReport))
            {
                if (entityData.Length % 16 != 0)
                {
                    throw new Exception("");
                }
            }
            else
            {
                //do nothing;
            }

        }
    }
}
