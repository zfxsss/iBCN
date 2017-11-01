using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Configuration;
using Metocean.iBCN.Message.Interface;
using Metocean.iBCN.Message.Entity;

namespace Metocean.iBCN.Message
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Msg<T> : IMsg<T>, IMsg where T : iBCNMessage, new()
    {
        /// <summary>
        /// recursively parse the bytes
        /// </summary>
        /// <param name="data"></param>
        public T ParseBytes(byte[] entityData)
        {
            EntityBytes = entityData;

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

        public byte[] EntityBytes { get; private set; }

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
        internal Msg(int cmdType, int subCmdType, byte[] entityData) : this(cmdType, subCmdType)
        {
            //ParseBytes(entityData);
            MessageEntity.FromBytes(entityData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        internal Msg(byte[] entityData)
        {
            MessageEntity = new T();
            //ParseBytes(entityData);
            MessageEntity.FromBytes(entityData);
        }

    }
}
