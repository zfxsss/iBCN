using Metocean.iBCN.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNConsole.Device
{
    /// <summary>
    /// 
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private static object mutex = new object();

        /// <summary>
        /// 
        /// </summary>
        private static DeviceEnum? currentDevice = null;

        /// <summary>
        /// 
        /// </summary>
        public static DeviceEnum? CurrentDevice
        {
            get
            {
                lock (mutex)
                {
                    return currentDevice;
                }
            }
            set
            {
                lock (mutex)
                {
                    currentDevice = value;
                }
            }
        }

    }
}
