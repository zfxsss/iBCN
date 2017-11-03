using Metocean.iBCN.Message.Entity.EventData;
using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EventReport : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public struct PostionMetaData
        {
            /// <summary>
            /// 
            /// </summary>
            public bool Motion { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            public int Satellites { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public decimal HDOP { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private byte eventCode;

        /// <summary>
        /// 
        /// </summary>
        public byte EventCode
        {
            get
            {
                return eventCode;
            }
            private set
            {
                eventCode = value;
                EventData = EvtDataBuilder.CreateEventData(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public iBCNEvtData EventData { get; private set; }
        //byte[] EventData { get; set; } = new byte[11];

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PostionMetaData? GetPositionMetaData()
        {
            //to be implemented
            return new PostionMetaData() { HDOP = 1.5M, Motion = false, Satellites = 5 };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
        }
    }
}
