using Metocean.iBCN.Command;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNConsole.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class Preprocessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdInfo"></param>
        /// <returns></returns>
        public static IPayload GetPayload(string[] cmdInfo, DeviceEnum? di = null)
        {
            if (cmdInfo[0].ToLower() == "clearmemorylog")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "getdiagnosticstatus")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "getextendeddiagnostics")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "getidentification")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "getlogmemorystatus")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "readconfigmode")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "readdatetime")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "requestpositionreportlast")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "requestpositionreportnew")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "resetreportingindex")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "sendiridiummessage")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "setdebugoutputlevel")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "startbootloaderprocess")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "startdownloadall")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "startdownloadnew")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "stopdownload")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "writeconfigmode")
            {
                return null;
            }
            else if (cmdInfo[0].ToLower() == "writedatetime")
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdInfo"></param>
        /// <returns></returns>
        public static UInt16 GetSequenceNum(string[] cmdInfo)
        {
            if (cmdInfo.Length < 2)
            {
                throw new Exception("");
            }

            UInt16 seq = 0;
            if (UInt16.TryParse(cmdInfo[1], out seq))
            {
                return seq;
            }

            throw new Exception("Invalid input");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdInfo"></param>
        /// <returns></returns>
        public static string GetCommandName(string[] cmdInfo)
        {
            if (cmdInfo.Length < 1)
            {
                throw new Exception("");
            }

            if (CommandSupported.Count(x => x.ToLower() == cmdInfo[0].ToLower()) < 1)
            {
                throw new Exception("Command not supported");
            }

            return cmdInfo[0];
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly string[] CommandSupported = new string[] {
                "ClearMemoryLog" ,
                "GetDiagnosticStatus",
                "GetExtendedDiagnostics",
                "GetIdentification",
                "GetLogMemoryStatus",
                "ReadConfigMode",
                "ReadDateTime",
                "RequestPositionReportLast",
                "RequestPositionReportNew",
                "ResetReportingIndex",
                "SendIridiumMessage",
                "SetDebugOutputLevel",
                "StartBootloaderProcess",
                "StartDownloadAll",
                "StartDownloadNew",
                "StopDownload",
                "WriteConfigMode",
                "WriteDateTime"
            };
    }
}
