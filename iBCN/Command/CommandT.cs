using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Interface;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Definition.Interface;
using Metocean.iBCN.Configuration;

namespace Metocean.iBCN.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICmd<T>, ICmd where T : ICmdBytes, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public Type CmdType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public T AppendBytes(object payload)
        {
            var cmdConfig = JsonConfigReader.GetConfigItem("");

            //to be implemented
            return CmdBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CmdTypeCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubCmdTypeCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public T CmdBytes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdDefinition"></param>
        public Command(int cmdType, int subCmdType)
        {
            CmdTypeCode = cmdType;
            SubCmdTypeCode = subCmdType;
            CmdBytes = new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        private Command(int cmdType, int subCmdType, object payload) : this(cmdType, subCmdType)
        {
            AppendBytes(payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmdBytes GetCommandBytes(string cmdName, object payload)
        {
            return (new Command<ClearMemoryLog>(0, 0, payload)).CmdBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmd GetCommand(string cmdName, object payload)
        {
            return new Command<ClearMemoryLog>(0, 0, payload);
        }
    }
}
