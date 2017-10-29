using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Interface;
using Metocean.iBCN.Message.Entity.Interface;
using Metocean.iBCN.Message.Entity;
using Metocean.iBCN.Configuration;

namespace Metocean.iBCN.Message
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Msg<T> : IMsg where T : IMsgEntity, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void ParseBytes(byte[] data)
        {
            var msgConfig = JsonConfigReader.GetConfigItem("");
        }

        /// <summary>
        /// 
        /// </summary>
        public T MessageEntity
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageName"></param>
        public Msg()
        {
            MessageEntity = new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Msg(byte[] msgData) : this()
        {
            //MessageEntity = MsgBuilder.BuildMsg<T>(msgData);
            //MessageEntity = new T();
            ParseBytes(msgData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static IMsgEntity GetMessageEntity(byte[] data)
        {
            var msg = new Msg<EventReport>();
            msg.ParseBytes(data);
            return msg.MessageEntity;
            //return (new Msg<EventReport>(data)).MessageEntity;
        }
    }
}
