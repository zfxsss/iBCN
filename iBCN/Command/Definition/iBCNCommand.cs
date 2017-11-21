using Metocean.iBCN.Command.Definition.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Command.Definition
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class iBCNCommand : ICmdBytes
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Body { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasPayload
        {
            get
            {
                if (GetType() == typeof(SetDebugOutputLevel))
                {
                    return true;
                }
                else if (GetType() == typeof(GetDiagnosticStatus))
                {
                    return false;
                }
                else if (GetType() == typeof(GetLogMemoryStatus))
                {
                    return false;
                }
                else if (GetType() == typeof(ReadDateTime))
                {
                    return false;
                }
                else if (GetType() == typeof(WriteDateTime))
                {
                    return true;
                }
                else if (GetType() == typeof(GetIdentification))
                {
                    return false;
                }
                else if (GetType() == typeof(GetExtendedDiagnostics))
                {
                    return false;
                }
                else if (GetType() == typeof(RequestPositionReport_Last))
                {
                    return false;
                }
                else if (GetType() == typeof(RequestPositionReport_New))
                {
                    return false;
                }
                else if (GetType() == typeof(ReadConfigMode))
                {
                    return true;
                }
                else if (GetType() == typeof(WriteConfigMode))
                {
                    return true;
                }
                else if (GetType() == typeof(ClearMemoryLog))
                {
                    return false;
                }
                else if (GetType() == typeof(ResetReportingIndex))
                {
                    return false;
                }
                else if (GetType() == typeof(StartDownloadAll))
                {
                    return false;
                }
                else if (GetType() == typeof(StartDownloadNew))
                {
                    return false;
                }
                else if (GetType() == typeof(StopDownload))
                {
                    return false;
                }
                else if (GetType() == typeof(StartBootloaderProcess))
                {
                    return false;
                }
                else if (GetType() == typeof(SendIridiumMessage))
                {
                    return true;
                }

                //some commands could support the mode either with or without payload
                return null;
            }
        }

    }
}
