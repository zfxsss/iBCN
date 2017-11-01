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
        /// recursively parse the bytes
        /// </summary>
        /// <param name="data"></param>
        public T ParseBytes(byte[] entityData)
        {
            var msgConfig = JsonConfigReader.GetConfigItem(typeof(T).Name);

            var cursorPosition = 0;
            int byteOccupied = 0;

            //the size of the Message Entity is already defined
            if ((byteOccupied = msgConfig.Value<int>("BytesOccupied")) > 0)
            {
                if (entityData.Length < byteOccupied)
                {
                    throw new Exception("Not enough bytes provided");
                }
                else
                {
                    //start parsing the bytes
                    var propertiesConfig = msgConfig["PropertiesConfig"];

                    //new Msg<>

                }
            }
            //the size of the Message Entity is not defined
            else
            {

            }



            //needs to be implemented

            return MessageEntity;
            //return new T();
        }

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
        internal Msg(int cmdType, int subCmdType, byte[] msgData) : this(cmdType, subCmdType)
        {
            //MessageEntity = MsgBuilder.BuildMsg<T>(msgData);
            //MessageEntity = new T();
            //ParseBytes(msgData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgData"></param>
        internal Msg(byte[] msgData)
        {
            MessageEntity = new T();
            ParseBytes(msgData);
        }

    }
}
