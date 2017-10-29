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
    public class Msg<T> : IMsg<T>, IMsg where T : IMsgEntity, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public T ParseBytes(byte[] data)
        {
            var msgConfig = JsonConfigReader.GetConfigItem("");
            //needs to be implemented

            return MessageEntity;
            //return new T();
        }

        /// <summary>
        /// 
        /// </summary>
        public int CmdType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubCmdType { get; private set; }

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
        public Msg(int cmdType, int subCmdType)
        {
            CmdType = cmdType;
            SubCmdType = subCmdType;
            MessageEntity = new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private Msg(int cmdType, int subCmdType, byte[] msgData) : this(cmdType, subCmdType)
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
            //return (new Msg<EventReport>(0, 0)).ParseBytes(data);
            return (new Msg<EventReport>(0, 0, data)).MessageEntity;

        }
    }
}
