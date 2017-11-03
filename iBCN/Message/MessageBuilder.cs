using Metocean.iBCN.Message.Entity;
using Metocean.iBCN.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message
{
    public class MessageBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static iBCNMessage GetMessageEntity(byte[] data)
        {
            if (data[0] == 0x01 && data[1] == 0x81)
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
            else if ((data[0] == 0x03 && data[1] == 0x90) || (data[0] == 0x03 && data[1] == 0x91))
            {
                return new Msg<EventReport>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
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
                || (data[0] == 0x07 && data[1] == 0x84) || (data[0] == 0x09 && data[1] == 0xA0) || (data[0] == 0x07 && data[1] == 0xB0)
                || (data[0] == 0x07 && data[1] == 0xC0) || (data[0] == 0x09 && data[1] == 0xFE))
            {
                return new Msg<Acknowledgement>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else if (data[0] == 0x03 && data[1] == 0xA0)
            {
                return new Msg<Entity.DateTime>(data[0], data[1], data[2], data.Skip(3).ToArray()).MessageEntity;
            }
            else
            {
                throw new Exception("Unknown Message");
            }
        }

        /// <summary>
        /// normally it will be invoked in ParseBytes method
        /// </summary>
        /// <param name="MsgName"></param>
        /// <param name="entitydata"></param>
        /// <returns></returns>
        public static iBCNMessage GetMessageEntity(string msgName, byte[] entitydata)
        {
            if (msgName == "EventReport")
            {
                return new Msg<EventReport>(entitydata).MessageEntity;
            }
            else if (msgName == "ExtendedStatus")
            {
                return new Msg<ExtendedStatus>(entitydata).MessageEntity;
            }
            else if (msgName == "Identity")
            {
                return new Msg<Identity>(entitydata).MessageEntity;
            }
            else if (msgName == "LogStatus")
            {
                return new Msg<LogStatus>(entitydata).MessageEntity;
            }
            else if (msgName == "Mode")
            {
                return new Msg<Mode>(entitydata).MessageEntity;
            }
            else if (msgName == "PositionReport")
            {
                return new Msg<EventReport>(entitydata).MessageEntity;
            }
            else if (msgName == "RecordsPacket")
            {
                return new Msg<RecordsPacket>(entitydata).MessageEntity;
            }
            else if (msgName == "Status")
            {
                return new Msg<Status>(entitydata).MessageEntity;
            }
            else if (msgName == "Acknowledgement")
            {
                return new Msg<Acknowledgement>(entitydata).MessageEntity;
            }
            else if (msgName == "DateTime")
            {
                return new Msg<Entity.DateTime>(entitydata).MessageEntity;
            }
            else
            {
                throw new Exception("Unknown Message");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IMsg GetMessage(byte[] data)
        {
            if (data[0] == 0x01 && data[1] == 0x81)
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
                return new Msg<Mode>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if ((data[0] == 0x03 && data[1] == 0x90) || (data[0] == 0x03 && data[1] == 0x91))
            {
                return new Msg<EventReport>(data[0], data[1], data[2], data.Skip(3).ToArray());
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
                || (data[0] == 0x07 && data[1] == 0x84) || (data[0] == 0x09 && data[1] == 0xA0) || (data[0] == 0x07 && data[1] == 0xB0)
                || (data[0] == 0x07 && data[1] == 0xC0) || (data[0] == 0x09 && data[1] == 0xFE))
            {
                return new Msg<Acknowledgement>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else if (data[0] == 0x03 && data[1] == 0xA0)
            {
                return new Msg<Entity.DateTime>(data[0], data[1], data[2], data.Skip(3).ToArray());
            }
            else
            {
                throw new Exception("Unknown Message");
            }

        }
    }
}
