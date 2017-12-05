using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Message.Interface;
using Metocean.iBCN.Message.Entity;
using Metocean.iBCN.iBCNException.Message;

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
        /// <param name="entityData"></param>
        public T ParseBytes(byte[] entityData)
        {
            #region test
            /*
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
            */
            #endregion

            try
            {
                EntityBytes = entityData;
                MessageEntity.FromBytes(EntityBytes);

                return MessageEntity;
            }
            catch (Exception ex)
            {
                throw new MessageDomainException("Exception is raised in message processing", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
        public int Sequence { get; private set; }

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
        /// <param name="cmdType"></param>
        /// <param name="subCmdType"></param>
        /// <param name="sequence"></param>
        public Msg(int cmdType, int subCmdType, int sequence)
        {
            CmdType = cmdType;
            SubCmdType = subCmdType;
            Sequence = sequence;
            MessageEntity = new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="subCmdType"></param>
        /// <param name="sequence"></param>
        /// <param name="entityData"></param>
        internal Msg(int cmdType, int subCmdType, int sequence, byte[] entityData) : this(cmdType, subCmdType, sequence)
        {
            ParseBytes(entityData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        internal Msg(byte[] entityData)
        {
            MessageEntity = new T();
            ParseBytes(entityData);
        }

    }
}
