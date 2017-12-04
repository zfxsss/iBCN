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
    public class EventReport : iBCNMessage, IMsgEntity
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
        private UInt16 eventCode;

        /// <summary>
        /// 
        /// </summary>
        public UInt16 EventCode
        {
            get
            {
                return eventCode;
            }
            private set
            {
                eventCode = value;
                EventData = EvtDataBuilder.CreateEventData(eventCode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public iBCNEvtData EventData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PostionMetaData? GetPositionMetaData()
        {
            if (eventCode >= 128)
            {
                return new PostionMetaData() { HDOP = 1.5M, Motion = false, Satellites = 5 };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Timestamp = new DateTime();
            Timestamp.FromBytes(entityData.Take(4).ToArray());
            eventCode = entityData.Skip(4).Take(1).ToArray()[0];
            EventCode = entityData.Skip(4).Take(1).ToArray()[0];
            EventData.FromBytes(entityData.Skip(5).Take(11).ToArray());
        }
    }
}
