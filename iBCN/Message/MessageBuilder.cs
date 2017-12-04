using Metocean.iBCN.iBCNException.Message;
using Metocean.iBCN.Message.Entity;
using Metocean.iBCN.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IMsgEntity GetMessageEntity(byte[] data)
        {
            if ((data[0] == 0x01 && data[1] == 0x81) || (data[0] == 0x03 && data[1] == 0x90) || (data[0] == 0x03 && data[1] == 0x91))
            {
                return new Msg<EventReport>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x01 && data[1] == 0xFD)
            {
                return new Msg<MultiplePositionReport>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0x84)
            {
                return new Msg<ExtendedStatus>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0x81)
            {
                return new Msg<Identity>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x09 && data[1] == 0x81)
            {
                return new Msg<LogStatus>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x05 && data[1] == 0x81)
            {
                return new Msg<Mode>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x09 && data[1] == 0xFF)
            {
                return new Msg<RecordsPacket>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0x82)
            {
                return new Msg<Status>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if ((data[0] == 0x03 && data[1] == 0xA1) || (data[0] == 0x05 && data[1] == 0x91) || (data[0] == 0x05 && data[1] == 0xA0)
                || (data[0] == 0x07 && data[1] == 0x84) || (data[0] == 0x09 && data[1] == 0xA0) || (data[0] == 0x09 && data[1] == 0xB0)
                || (data[0] == 0x09 && data[1] == 0xC0) || (data[0] == 0x09 && data[1] == 0xFE) || (data[0] == 0x03 && data[1] == 0xB0))
            {
                return new Msg<Acknowledgement>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0xA0)
            {
                return new Msg<Entity.DateTime>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0xB1)
            {
                return new Msg<ReceiveIridiumMessage>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if ((data[0] == 0x09 && data[1] == 0x90) || (data[0] == 0x09 && data[1] == 0x91))
            {
                return new Msg<StartDownload>(data[0], data[1], data[3], data.Skip(3).ToArray()).MessageEntity;
            }
            else
            {
                throw new MessageDomainException("Unknown message type code, unable to parse the byte stream");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IMsg GetMessage(byte[] data)
        {
            if ((data[0] == 0x01 && data[1] == 0x81) || (data[0] == 0x03 && data[1] == 0x90) || (data[0] == 0x03 && data[1] == 0x91))
            {
                return new Msg<EventReport>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x01 && data[1] == 0xFD)
            {
                return new Msg<MultiplePositionReport>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0x84)
            {
                return new Msg<ExtendedStatus>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0x81)
            {
                return new Msg<Identity>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x09 && data[1] == 0x81)
            {
                return new Msg<LogStatus>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x05 && data[1] == 0x81)
            {
                return new Msg<ReadConfigMode>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x09 && data[1] == 0xFF)
            {
                return new Msg<RecordsPacket>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0x82)
            {
                return new Msg<Status>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if ((data[0] == 0x03 && data[1] == 0xA1) || (data[0] == 0x05 && data[1] == 0x91) || (data[0] == 0x05 && data[1] == 0xA0)
                || (data[0] == 0x07 && data[1] == 0x84) || (data[0] == 0x09 && data[1] == 0xA0) || (data[0] == 0x09 && data[1] == 0xB0)
                || (data[0] == 0x09 && data[1] == 0xC0) || (data[0] == 0x09 && data[1] == 0xFE) || (data[0] == 0x03 && data[1] == 0xB0))
            {
                return new Msg<Acknowledgement>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0xA0)
            {
                return new Msg<Entity.DateTime>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0xB1)
            {
                return new Msg<ReceiveIridiumMessage>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if ((data[0] == 0x09 && data[1] == 0x90) || (data[0] == 0x09 && data[1] == 0x91))
            {
                return new Msg<StartDownload>(data[0], data[1], data[3], data.Skip(3).ToArray());
            }
            else
            {
                throw new MessageDomainException("Unknown message type code, unable to parse the byte stream");
            }

        }

        /// <summary>
        ///  normally it will be invoked in ParseBytes method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitydata"></param>
        /// <returns></returns>
        public static T GetMessageEntity<T>(byte[] entitydata) where T : IMsgEntity, new()
        {
            return new Msg<T>(entitydata).MessageEntity;
        }

    }
}
