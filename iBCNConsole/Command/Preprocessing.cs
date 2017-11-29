using Metocean.iBCN.Command;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Device;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
            /*
             * Will read payload information from cmdInfo[2] 
             */

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
                if (cmdInfo.Length < 3)
                {
                    throw new Exception("No enough data to build payload");
                }

                var payload = new Metocean.iBCN.Command.Payload.ReadConfigMode();
                payload.Index = ushort.Parse(cmdInfo[2]);
                return payload;
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
                if (cmdInfo.Length < 3)
                {
                    throw new Exception("No enough data to build payload");
                }

                var payload = new Metocean.iBCN.Command.Payload.SendIridiumMessage();
                var bytes = new byte[] { };
                foreach (var s in cmdInfo.Skip(2).ToArray())
                {
                    bytes = bytes.Concat(new byte[] { byte.Parse(s) }).ToArray();
                }

                payload.Message = bytes;
                return payload;
            }
            else if (cmdInfo[0].ToLower() == "setdebugoutputlevel")
            {
                if (cmdInfo.Length < 3)
                {
                    throw new Exception("No enough data to build payload");
                }

                var payload = new Metocean.iBCN.Command.Payload.SetDebugOutputLevel();
                payload.DebugLevel = ushort.Parse(cmdInfo[2]);
                return payload;
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
                if (cmdInfo.Length < 10)
                {
                    throw new Exception("No enough data to build payload");
                }

                var payload = new Metocean.iBCN.Command.Payload.WriteConfigMode();
                payload.Index = ushort.Parse(cmdInfo[2]);
                payload.Mode = new Metocean.iBCN.Message.Entity.Mode[1];
                payload.Mode[0] = new Metocean.iBCN.Message.Entity.Mode(uint.Parse(cmdInfo[3]), uint.Parse(cmdInfo[4]),
                                                                        ushort.Parse(cmdInfo[5]), ushort.Parse(cmdInfo[6]),
                                                                        ushort.Parse(cmdInfo[7]), ushort.Parse(cmdInfo[8]),
                                                                        ushort.Parse(cmdInfo[9]));
                return payload;
            }
            else if (cmdInfo[0].ToLower() == "writedatetime")
            {
                if (cmdInfo.Length < 3)
                {
                    throw new Exception("No enough data to build payload");
                }

                if (cmdInfo[2].ToLower() == "now")
                {
                    var payload = new Metocean.iBCN.Command.Payload.WriteDateTime();
                    payload.Date_Time = DateTime.Now;
                    return payload;
                }
                else
                {
                    var payload = new Metocean.iBCN.Command.Payload.WriteDateTime();
                    payload.Date_Time = DateTime.Parse(cmdInfo[2]);
                    return payload;
                }

            }

            //return null if no match
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
                throw new Exception("No sequence number found");
            }

            UInt16 seq;
            if (UInt16.TryParse(cmdInfo[1], out seq))
            {
                return seq;
            }

            throw new Exception("Invalid sequence number");
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
                throw new Exception("Invalid Input");
            }

            if (CommandSupported.Count(x => x.ToLower() == cmdInfo[0].ToLower()) < 1)
            {
                throw new Exception("Unsupported Command");
            }

            return CommandSupported.Where(x => x.ToLower() == cmdInfo[0].ToLower()).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="defaultModeEnabled"></param>
        /// <returns>true: default mode; false: not default mode</returns>
        public static bool AnalyzeCommandMode(ref string[] info, bool defaultModeEnabled)
        {
            if (info.Length > 1)
            {
                return false;
            }

            //default mode?
            if (defaultModeEnabled)
            {
                var config = JObject.Parse(File.ReadAllText(@"Configuration\DefaultParameters.json"));

                //get default sequence num
                var sequenceNum = config["DefaultSequenceNumber"].Value<string>();
                info = info.Concat(new string[] { sequenceNum }).ToArray();

                //deal with payload
                var cmdName = GetCommandName(info);
                var payload = config["Command_DefaultPayload"][cmdName];

                if (payload != null)
                {
                    info = info.Concat(payload.Values<string>().ToArray()).ToArray();
                }

                return true;
            }

            return false;
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
