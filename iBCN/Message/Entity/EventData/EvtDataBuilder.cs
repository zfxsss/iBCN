using Metocean.iBCN.iBCNException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    /// <summary>
    /// 
    /// </summary>
    public class EvtDataBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public static iBCNEvtData CreateEventData(UInt16 typeCode)
        {
            if (typeCode == 2)
            {
                return new PowerUp();
            }
            else if (typeCode == 3)
            {
                return new BatteryStatus();
            }
            else if ((typeCode == 21) || (typeCode == 7))
            {
                return new ConfigUpdate();
            }
            else if (typeCode == 9)
            {
                return new GpsTimeout();
            }
            else if (typeCode == 15)
            {
                return new TimeSet();
            }
            else if (typeCode == 16)
            {
                return new GpsPositionRequest();
            }
            else if ((typeCode == 10) || (typeCode == 20) || (typeCode == 22) || (typeCode == 14)
                || (typeCode == 1) || (typeCode == 4) || (typeCode == 5) || (typeCode == 6)
                || (typeCode == 8) || (typeCode == 11) || (typeCode == 12) || (typeCode == 13)
                || (typeCode == 17) || (typeCode == 18) || (typeCode == 19))
            {
                return new Common();
            }
            else if (typeCode >= 128)
            {
                return new Position();
            }
            else
            {
                throw new UnsupportedEventTypeCode("Unknown Event Data Type Code: " + typeCode.ToString());
            }
        }
    }
}
