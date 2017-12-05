using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.iBCNException;
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
        /// <summary>
        /// 
        /// </summary>
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
                    throw new InvalidDateTime("DateTime should be later than 1980/01/06T00:00:00: " + value.ToString());
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
