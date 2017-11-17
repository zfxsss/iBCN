using Metocean.iBCNLinkLayer.Link;
using Metocean.iBCN.Command;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Command.Payload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNLinkLayerFormApp
{
    public partial class Form1 : Form
    {

        BluetoothLink receiving;

        BluetoothLink sending;

        public Form1()
        {
            InitializeComponent();
        }


        //start receiving link layer
        private void button1_Click(object sender, EventArgs e)
        {
            receiving = new BluetoothLink();
            receiving.Open("COM3", false);
        }

        //start sending link layer
        private void button2_Click(object sender, EventArgs e)
        {
            sending = new BluetoothLink();
            sending.Open("COM4", false);
        }


        /// <summary>
        /// SetDebugOutputLevel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var payload = new Metocean.iBCN.Command.Payload.SetDebugOutputLevel();
            payload.DebugLevel = 0;

            var cmdbytes = Command<Metocean.iBCN.Command.Definition.SetDebugOutputLevel>.GetCommandBytes(2, payload);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
            //receiving.Send(new byte[] { 0xAA, 0x55, 0x00, 0x04, 0x05, 0x20, 0x02, 0x01, 0xCB, 0xD6, 0xFF, 0xCC });
        }

        /// <summary>
        /// GetDiagnosticStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<GetDiagnosticStatus>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// GetLogMemoryStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<GetLogMemoryStatus>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// ReadDateTime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<ReadDateTime>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// WriteDateTime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            var payload = new Metocean.iBCN.Command.Payload.WriteDateTime();
            payload.Date_Time = new System.DateTime(2011, 2, 1);

            var cmdbytes = Command<Metocean.iBCN.Command.Definition.WriteDateTime>.GetCommandBytes(1, payload);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// GetIdentification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<GetIdentification>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// GetExtendedDiagnostics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<GetExtendedDiagnostics>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// RequestPositionReport_Last
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<RequestPositionReport_Last>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// RequestPositionReport_New
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<RequestPositionReport_New>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// ReadConfigMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            var payload = new Metocean.iBCN.Command.Payload.ReadConfigMode();
            payload.Index = 0x09;

            var cmdbytes = Command<Metocean.iBCN.Command.Definition.ReadConfigMode>.GetCommandBytes(1, payload);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// WriteConfigMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            var payload = new Metocean.iBCN.Command.Payload.WriteConfigMode();
            payload.Index = 0xFF;
            payload.Mode = new Metocean.iBCN.Message.Entity.Mode[10];
            payload.Mode[0] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[1] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[2] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[3] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[4] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[5] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[6] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[7] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[8] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);
            payload.Mode[9] = new Metocean.iBCN.Message.Entity.Mode(0, 300, 0, 1, 1, 1, 1);


            var cmdbytes = Command<Metocean.iBCN.Command.Definition.WriteConfigMode>.GetCommandBytes(1, payload);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// ClearMemoryLog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<ClearMemoryLog>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// ResetReportingIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<ResetReportingIndex>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// StartDownloadAll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<StartDownloadAll>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// StartDownloadNew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            byte a = 0x0A;
            UInt16 x = a;

            var cmdbytes = Command<StartDownloadNew>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// StopDownload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<StopDownload>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// SendIridiumMessage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            var payload = new Metocean.iBCN.Command.Payload.SendIridiumMessage();
            payload.Message = new byte[] { 0x11, 0x11 };
            var cmdbytes = Command<Metocean.iBCN.Command.Definition.SendIridiumMessage>.GetCommandBytes(1, payload);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }

        /// <summary>
        /// StartBootloaderProcess
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)
        {
            var cmdbytes = Command<StartBootloaderProcess>.GetCommandBytes(1, null);
            receiving.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(cmdbytes.Body));
        }
    }
}
