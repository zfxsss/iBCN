using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Interface;
using Metocean.iBCN.Message.Entity.Interface;

namespace Metocean.iBCN.Message
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Message<T> : IMsg where T : IMsgEntity
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
        public Message(string messageName)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Message(byte[] data)
        {

        }
    }
}
