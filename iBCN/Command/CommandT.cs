using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Command.Definition.Interface;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Command.Interface;
using Metocean.iBCN.iBCNException.Command;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.iBCNException;

namespace Metocean.iBCN.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICmd<T>, ICmd where T : iBCNCommand, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public T AppendBytes(UInt16 sequence, IPayload payload)
        {
            try
            {
                Sequence = sequence;
                Payload = payload;

                //append sequence first
                CmdBytes.Body = CmdBytes.Body.Concat(new byte[] { BitConverter.GetBytes(sequence)[0] }).ToArray();

                if (CmdBytes.HasPayload != null)
                {
                    //append payload
                    if (CmdBytes.HasPayload == true)
                    {
                        if (Payload == null)
                        {
                            throw new NullPayload("CommandType: " + CmdTypeCode.ToString() + "; SubCommandType: " + SubCmdTypeCode.ToString());
                        }

                        if (Payload.CommandsSupported.Count(x => x.Item1 == CmdTypeCode && x.Item2 == SubCmdTypeCode) < 1)
                        {
                            throw new CommandPayloadUnmatched("Command: " + typeof(T).Name + "; Payload: " + Payload.GetType().Name);
                        }

                        var payloadBytes = Payload.ToBytes();
                        CmdBytes.Body = CmdBytes.Body.Concat(payloadBytes).ToArray();
                    }

                }
                else
                {
                    //append payload whatever
                    if (payload != null)
                    {
                        var payloadBytes = Payload.ToBytes();
                        CmdBytes.Body = CmdBytes.Body.Concat(payloadBytes).ToArray();
                    }
                }

                return CmdBytes;
            }
            catch (Exception ex)
            {
                throw new CommandDomainException("Exception raised in command processing", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 CmdTypeCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 SubCmdTypeCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private UInt16 sequence;

        /// <summary>
        /// 
        /// </summary>
        public UInt16 Sequence
        {
            get
            {
                return sequence;
            }
            private set
            {
                if ((value > 255) || (value < 0))
                {
                    throw new InvalidSequenceNumber("Sequence Number: " + value.ToString());
                }
                else
                {
                    sequence = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IPayload Payload { get; private set; }

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
        private Command(UInt16 sequence, IPayload payload = null) : this()
        {
            AppendBytes(sequence, payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmdBytes GetCommandBytes(UInt16 sequence = 0, IPayload payload = null)
        {
            return new Command<T>(sequence, payload).CmdBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static ICmd GetCommand(UInt16 sequence = 0, IPayload payload = null)
        {
            return new Command<T>(sequence, payload);
        }
    }
}
