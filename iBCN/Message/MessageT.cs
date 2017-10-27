using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Interface;
using Metocean.iBCN.Message.Entity.Interface;
using Metocean.iBCN.Message.Entity;

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
        public Type MsgType
        {
            get
            {
                return typeof(T);
            }
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
        public Msg(byte[] msgData)
        {
            MessageEntity = MsgBuilder.BuildMsg<T>(msgData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static IMsgEntity GetMessageEntity(byte[] data)
        {
            return (new Msg<EventReport>(data)).MessageEntity;

        }
    }
}
