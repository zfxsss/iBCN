using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCNLinkLayer.Wrapper
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkLayerWrapper
    {
        private static readonly UInt16[] tableCRC16A =
        {
            0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
            0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
            0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
            0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
            0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
            0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
            0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
            0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
            0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
            0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
            0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12,
            0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
            0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41,
            0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
            0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
            0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
            0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
            0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
            0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
            0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
            0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
            0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
            0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
            0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
            0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
            0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
            0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
            0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
            0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
            0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
            0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
            0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkLayerBytes"></param>
        /// <param name="outputBytes"></param>
        /// <param name="parsedLength"></param>
        /// <returns></returns>
        public static LinkLayerBytesType ParseLinkLayerBytes(byte[] linkLayerBytes, out byte[] outputBytes, out int parsedLength)
        {
            bool potentialiBCNMsg = false;

            Func<byte[], byte[], bool> CRCCheck = (calculatedBytes, crcResult) =>
            {
                var crt = (UInt16)0xFFFF;

                foreach (var b in calculatedBytes)
                {
                    int arrayPosition = crt & 0xFF00;
                    arrayPosition /= 0x0100;
                    arrayPosition = (arrayPosition ^ b);
                    arrayPosition = arrayPosition & 0x000000FF;
                    crt = (UInt16)(tableCRC16A[arrayPosition] ^ ((((long)crt) * 0x0100) & 0xFFFF));
                }

                if (crt == BitConverter.ToUInt16(crcResult.Reverse().ToArray(), 0)) //modify it later
                {
                    return true;
                }
                else
                {
                    return false;
                }

            };

            if (linkLayerBytes == null || linkLayerBytes.Length == 0)
            {
                outputBytes = null;
                parsedLength = 0;
                return LinkLayerBytesType.None;
            }

            if (linkLayerBytes.Length < 2)
            {
                outputBytes = null;
                parsedLength = 0;
                return LinkLayerBytesType.None;
            }

            if ((linkLayerBytes[0] == 0xAA) && (linkLayerBytes[1] == 0x55))
            {
                potentialiBCNMsg = true;
            }
            else
            {
                //could deal with special plain text here
            }

            if (potentialiBCNMsg)
            {
                for (int i = 1; i < linkLayerBytes.Length; i++)
                {
                    if ((linkLayerBytes[i - 1] == 0xFF) && (linkLayerBytes[i] == 0xCC))
                    {
                        if (!CRCCheck(linkLayerBytes.Skip(2).Take(i + 1 - 4 - 2).ToArray(), linkLayerBytes.Skip(i + 1 - 4).Take(2).ToArray()))
                        {
                            outputBytes = null;
                            parsedLength = i + 1;
                            return LinkLayerBytesType.iBCNMsg_Invalid;

                        }
                        else
                        {
                            outputBytes = linkLayerBytes.Skip(4).Take(i + 1 - 4 - 4).ToArray();
                            parsedLength = i + 1;
                            return LinkLayerBytesType.iBCNMsg;
                        }
                    }

                    if (i > 260)
                    {
                        throw new Exception("too long iBCNMsg, it's an error!");
                    }

                }

                outputBytes = null;
                parsedLength = 0;
                return LinkLayerBytesType.None;
            }
            else
            {
                for (int i = 1; i < linkLayerBytes.Length; i++)
                {
                    if ((linkLayerBytes[i - 1] == 0xAA) && (linkLayerBytes[i] == 0x55))
                    {
                        outputBytes = linkLayerBytes.Take(i - 1).ToArray();
                        parsedLength = i - 1;
                        return LinkLayerBytesType.PlainText;
                    }
                }

                outputBytes = linkLayerBytes;
                parsedLength = linkLayerBytes.Length;
                return LinkLayerBytesType.PlainText;
            }
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
                var dataTobeCalculated = packetDataLength.Concat(packetData);
                var crt = (UInt16)0xFFFF;

                foreach (var b in dataTobeCalculated)
                {
                    int arrayPosition = crt & 0xFF00;
                    arrayPosition /= 0x0100;
                    arrayPosition = (arrayPosition ^ b);
                    arrayPosition = arrayPosition & 0x000000FF;
                    crt = (UInt16)(tableCRC16A[arrayPosition] ^ ((((long)crt) * 0x0100) & 0xFFFF));
                }

                return BitConverter.GetBytes(crt).Reverse().ToArray();
            };

            var lengthBytes = BitConverter.GetBytes(applicationLayerMsg.Length).Reverse().Skip(2).ToArray();
            //to form the full message
            return (new byte[] { 0xAA, 0x55 }).Concat(lengthBytes).Concat(applicationLayerMsg).Concat(CRCCalculation(lengthBytes, applicationLayerMsg)).Concat(new byte[] { 0xFF, 0xCC }).ToArray();
        }
    }
}
