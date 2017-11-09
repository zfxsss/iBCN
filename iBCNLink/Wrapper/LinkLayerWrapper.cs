using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.Wrapper
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkLayerWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkLayerMsg"></param>
        /// <param name="applicationMsg"></param>
        /// <returns></returns>
        public static bool UnwrapLinkLayerMessage(byte[] linkLayerMsg, out byte[] applicationMsg)
        {
            Func<byte[], byte[], bool> CRCCheck = (calculatedBytes, crcResult) =>
            {
                return true;
            };

            if ((linkLayerMsg[0] != 0xAA) && (linkLayerMsg[1] != 0x55))
            {
                throw new Exception("");
            }

            if ((linkLayerMsg[linkLayerMsg.Length - 2] == 0xFF) && (linkLayerMsg[linkLayerMsg.Length - 1] == 0xCC))
            {
                //end of the message, check CRC
                if (!CRCCheck(null, null))
                {
                    throw new Exception("");
                }
                else
                {
                    applicationMsg = null;
                }
            }

            if (linkLayerMsg.Length > 10000)
            {
                throw new Exception("");
            }

            applicationMsg = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationLayerMsg"></param>
        /// <returns></returns>
        public static byte[] WrapApplicationLayerMessage(byte[] applicationLayerMsg)
        {
            Func<byte[], byte[], byte[]> CRCCalculation = (packetDataLength, packetData) =>
            {
                return null;
            };
            return null;
        }
    }
}
