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
    public class DateTime : iBCNMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date_Time { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            //Date_Time = TimeZoneInfo.ConvertTime((new System.DateTime(1980, 1, 6)).AddSeconds(BitConverter.ToUInt32(entityData.Reverse().ToArray(), 0)), TimeZoneInfo.Utc, TimeZoneInfo.Local);
            Date_Time = (new System.DateTime(1980, 1, 6)).AddSeconds(BitConverter.ToUInt32(entityData.Reverse().ToArray(), 0));
        }
    }
}
