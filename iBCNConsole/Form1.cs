using iBCNConsole.Command;
using iBCNConsole.CommandText;
using iBCNConsole.Device;
using Metocean.iBCNLinkLayer.Link;
using ObjectPropertiesIteration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNConsole
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private BluetoothLink link;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            PropertiesIterator.CB += (msg) =>
            {
                PrintOut(msg, false);
            };

            CommandBuilder.CB += (o) =>
            {
                PropertiesIterator.PrintIteration(o);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="isError"></param>
        private void PrintOut(string msg, bool isError)
        {
            richTextBox1.Invoke(new Action(() =>
            {
                richTextBox1.MaxLength = 1024 * 8;

                richTextBox1.SelectionStart = richTextBox1.Text.Length;

                richTextBox1.SelectionColor = Color.White;
                if (checkBox3.Checked)
                {
                    if (richTextBox1.Text.Length != 0)
                    {
                        richTextBox1.AppendText("\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ":  ");
                    }
                    else
                    {
                        richTextBox1.AppendText(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ": ");
                    }

                    if (isError)
                    {
                        richTextBox1.SelectionColor = Color.Red;
                    }
                    richTextBox1.AppendText(msg);
                }
                else
                {
                    if (richTextBox1.Text.Length != 0)
                    {
                        msg = "\n" + msg;
                    }

                    if (isError)
                    {
                        richTextBox1.SelectionColor = Color.Red;
                    }

                    richTextBox1.AppendText(msg);
                }

                richTextBox1.ScrollToCaret();


            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var x = "ReadDateTime 1";

                string[] info = TextParser.GetSplittedStringArray(x);
                var cmdName = Preprocessing.GetCommandName(info);
                var seq = Preprocessing.GetSequenceNum(info);
                var payload = Preprocessing.GetPayload(info, DeviceInfo.CurrentDevice);

                var bytes = CommandBuilder.Build(cmdName, seq, payload, DeviceInfo.CurrentDevice);

                link.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(bytes.Body));

                PropertiesIterator.PrintIteration(bytes);
            }
            catch (Exception ex)
            {
                PrintOut(ex.Message, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            link = new BluetoothLink();
            link.Open("COM3", false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            link.Close();
        }
    }
}
