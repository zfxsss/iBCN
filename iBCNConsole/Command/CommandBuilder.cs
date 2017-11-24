using Metocean.iBCN.Command;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Definition.Interface;
using Metocean.iBCN.Command.Interface;
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
    public class CommandBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public static event Action<object> CB;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="seq"></param>
        /// <param name="payload"></param>
        /// <param name="de"></param>
        /// <returns></returns>
        public static ICmdBytes Build(string commandName, UInt16 seq = 0, IPayload payload = null, DeviceEnum? de = null)
        {
            if (commandName.ToLower() == "clearmemorylog")
            {
                var cmd = (Command<ClearMemoryLog>)Command<ClearMemoryLog>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "getdiagnosticstatus")
            {
                var cmd = (Command<GetDiagnosticStatus>)Command<GetDiagnosticStatus>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "getextendeddiagnostics")
            {
                var cmd = (Command<GetExtendedDiagnostics>)Command<GetExtendedDiagnostics>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "getidentification")
            {
                var cmd = (Command<GetIdentification>)Command<GetIdentification>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "getlogmemorystatus")
            {
                var cmd = (Command<GetLogMemoryStatus>)Command<GetLogMemoryStatus>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "readconfigmode")
            {
                var cmd = (Command<ReadConfigMode>)Command<ReadConfigMode>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "readdatetime")
            {
                var cmd = (Command<ReadDateTime>)Command<ReadDateTime>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "requestpositionreportlast")
            {
                var cmd = (Command<RequestPositionReport_Last>)Command<RequestPositionReport_Last>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "requestpositionreportnew")
            {
                var cmd = (Command<RequestPositionReport_New>)Command<RequestPositionReport_New>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "resetreportingindex")
            {
                var cmd = (Command<ResetReportingIndex>)Command<ResetReportingIndex>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "sendiridiummessage")
            {
                var cmd = (Command<SendIridiumMessage>)Command<SendIridiumMessage>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "setdebugoutputlevel")
            {
                var cmd = (Command<SetDebugOutputLevel>)Command<SetDebugOutputLevel>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "startbootloaderprocess")
            {
                var cmd = (Command<StartBootloaderProcess>)Command<StartBootloaderProcess>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "startdownloadall")
            {
                var cmd = (Command<StartDownloadAll>)Command<StartDownloadAll>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "startdownloadnew")
            {
                var cmd = (Command<StartDownloadNew>)Command<StartDownloadNew>.GetCommand();
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "stopdownload")
            {
                var cmd = (Command<StopDownload>)Command<StopDownload>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "writeconfigmode")
            {
                var cmd = (Command<WriteConfigMode>)Command<WriteConfigMode>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }
            else if (commandName.ToLower() == "writedatetime")
            {
                var cmd = (Command<WriteDateTime>)Command<WriteDateTime>.GetCommand(seq, payload);
                CB?.Invoke(cmd);
                return cmd.CmdBytes;
            }

            throw new Exception("Unsupported Command");

        }

    }
}
