using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Definition.Interface;
using Metocean.iBCN.Configuration;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Command.Interface;

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
        /// <param name="payload"></param>
        /// <returns></returns>
        public T AppendBytes(IPayload payload)
        {
            if (CmdBytes.HasPayload != null)
            {
                if ((bool)CmdBytes.HasPayload == true)
                {
                    var payloadBytes = payload.ToBytes();

                    //some logic need to be added here
                    CmdBytes.Body.Concat(payloadBytes);
                }

            }

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
        public Command()
        {
            CmdBytes = new T();
            CmdTypeCode = CmdBytes.Body[0];
            SubCmdTypeCode = CmdBytes.Body[1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        private Command(IPayload payload = null) : this()
        {
            AppendBytes(payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmdBytes GetCommandBytes(IPayload payload = null)
        {
            return new Command<T>(payload).CmdBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmd GetCommand(IPayload payload = null)
        {
            return new Command<T>(payload);
        }
    }
}
