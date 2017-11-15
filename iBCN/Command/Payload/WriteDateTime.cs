using Metocean.iBCN.Command.Payload.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Payload
{
    /// <summary>
    /// 
    /// </summary>
    public class WriteDateTime : IPayload
    {
        private DateTime date_Time = new DateTime(1980, 1, 6);
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date_Time
        {
            get
            {
                return date_Time;
            }
            set
            {
                if (value < new DateTime(1980, 1, 6))
                {
                    throw new Exception("");
                }
                date_Time = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return BitConverter.GetBytes((UInt32)(Date_Time - (new DateTime(1980, 1, 6))).TotalSeconds).Reverse().ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<uint, uint>[] CommandsSupported { get; } = new Tuple<uint, uint>[] { new Tuple<uint, uint>(0x03, 0x21) };
    }
}
