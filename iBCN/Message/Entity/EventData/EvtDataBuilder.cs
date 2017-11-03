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
        public static iBCNEvtData CreateEventData(int typeCode)
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
            else if (typeCode >= 128)
            {
                return new Position();
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
