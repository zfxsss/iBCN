using Metocean.iBCN.iBCNException;
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
    public abstract class iBCNMessage : IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public virtual void FromBytes(byte[] entityData)
        {
            if (GetType() == typeof(DateTime))
            {
                if (entityData.Length != 4)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"DateTime\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(Acknowledgement))
            {
                if (entityData.Length != 1)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"Acknowledgement\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(Status))
            {
                if (entityData.Length != 13)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"Status\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(LogStatus))
            {
                if (entityData.Length != 16)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"LogStatus\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(Identity))
            {
                if (entityData.Length != 128)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"Identity\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(ExtendedStatus))
            {
                if (entityData.Length != 83)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"ExtendedStatus\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(EventReport))
            {
                if (entityData.Length != 16)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"EventReport\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(Mode))
            {
                if (entityData.Length != 17)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"Mode\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(ReadConfigMode))
            {
                if (!((entityData.Length == 18) || (entityData.Length == 180)))
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"ReadConfigMode\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(RecordsPacket))
            {
                if ((entityData.Length > 16 * 12 + 4) || (entityData.Length % 16 != 4))
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"RecordsPacket\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(StartDownload))
            {
                if (entityData.Length != 9)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"StartDownload\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(ReceiveIridiumMessage))
            {
                if (entityData.Length > 240)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"ReceiveIridiumMessage\": " + entityData.Length.ToString());
                }
            }
            else if (GetType() == typeof(MultiplePositionReport))
            {
                if (entityData.Length % 16 != 0)
                {
                    throw new InvalidBytesLength("Invalid bytes length for \"MultiplePositionReport\": " + entityData.Length.ToString());
                }
            }
            else
            {
                //do nothing;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string IMsgEntity.ToString()
        {
            return null;
        }
    }
}
