using iBCNConsole.Command;
using iBCNConsole.CommandText;
using iBCNConsole.Device;
using Metocean.iBCN.Message;
using Metocean.iBCNLinkLayer.Link;
using ObjectPropertiesIteration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBCNConsole
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private SerialLink link;

        /// <summary>
        /// 
        /// </summary>
        private const string datetimestyle = "yyyy/MM/dd HH:mm:ss.fff";

        /// <summary>
        /// 
        /// </summary>
        private readonly string spaceForDatetime;

        /// <summary>
        /// 
        /// </summary>
        private const int consoleWindowMaxLength = 1024 * 16;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //combobox auto-complete
            foreach (var c in Preprocessing.CommandSupported)
            {
                comboBox_CommandInput.Items.Add(c);
            }

            comboBox_CommandInput.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_CommandInput.AutoCompleteMode = AutoCompleteMode.Suggest;

            //object iterator CB binding
            PropertiesIterator.CB += (prefixMsg, msg) =>
            {
                PrintOut(prefixMsg, msg, false);
                PrintOut_File(prefixMsg, msg);
            };

            //when a command is built, callback will be invoked
            CommandBuilder.CB += (o) =>
            {
                #region old output
                /*
                var cmdBuiltPrompt = "*** Command Built ***";
                if (checkBox_ShowLogTime.Checked)
                {
                    PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", cmdBuiltPrompt, false);
                    PropertiesIterator.PrintIteration(o, 0, spaceForDatetime);
                }
                else
                {
                    PrintOut("", cmdBuiltPrompt, false);
                    PropertiesIterator.PrintIteration(o, 0, "");
                }
                */
                #endregion

                AdvancedLogOutput(o, "*** Command Built ***");
            };

            //space initialization
            spaceForDatetime = "";
            for (int i = 0; i < 50; i++)
            {
                spaceForDatetime += " ";
            }

            //combobox is disbaled
            comboBox_CommandInput.Enabled = false;

            closePortToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="isError"></param>
        private void PrintOut(string prefixMsg, string msg, bool isError = false)
        {
            richTextBox_ConsoleWindow.Invoke(new Action(() =>
            {
                if (richTextBox_ConsoleWindow.Text.Length > 3 * consoleWindowMaxLength)
                {
                    richTextBox_ConsoleWindow.Text = new string(richTextBox_ConsoleWindow.Text.Skip(consoleWindowMaxLength).ToArray());
                }

                richTextBox_ConsoleWindow.SelectionStart = richTextBox_ConsoleWindow.Text.Length;
                richTextBox_ConsoleWindow.SelectionColor = Color.White;

                if (richTextBox_ConsoleWindow.Text.Length != 0)
                {
                    richTextBox_ConsoleWindow.AppendText("\n");
                    richTextBox_ConsoleWindow.SelectionColor = Color.White;
                    richTextBox_ConsoleWindow.AppendText(prefixMsg);
                }
                else
                {
                    richTextBox_ConsoleWindow.AppendText(prefixMsg);
                }

                if (isError)
                {
                    richTextBox_ConsoleWindow.SelectionColor = Color.Red;
                }

                richTextBox_ConsoleWindow.AppendText(msg);
                richTextBox_ConsoleWindow.ScrollToCaret();

            }));

        }

        /// <summary>
        /// output message to txt file
        /// </summary>
        /// <param name="prefixMsg"></param>
        /// <param name="msg"></param>
        private void PrintOut_File(string prefixMsg, string msg)
        {
            Invoke(new Action(() =>
            {
                try
                {
                    if (!Directory.Exists("log"))
                    {
                        Directory.CreateDirectory("log");
                    }

                    File.AppendAllLines(@"log\console_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", new string[] { prefixMsg + msg });
                }
                catch (Exception ex)
                {
                    var timestamp = DateTime.Now.ToString(datetimestyle);

                    if (checkBox_ShowLogTime.Checked)
                    {
                        PrintOut(timestamp + ":  ", ex.Message, true);
                    }
                    else
                    {
                        PrintOut("", ex.Message, true);
                    }
                }
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        private void SimpleLogOutput(string input)
        {
            var timestamp = DateTime.Now.ToString(datetimestyle);

            if (checkBox_ShowLogTime.Checked)
            {
                PrintOut(timestamp + ":  ", input, false);
            }
            else
            {
                PrintOut("", input, false);
            }

            PrintOut_File(timestamp + ":  ", input);
        }

        /// <summary>
        /// 
        /// </summary>
        private void AdvancedLogOutput(object o, string msgPrompt)
        {
            var timestamp = DateTime.Now.ToString(datetimestyle);

            if (checkBox_ShowLogTime.Checked)
            {
                PrintOut(timestamp + ":  ", msgPrompt, false);
                PrintOut_File(timestamp + ":  ", msgPrompt);
                PropertiesIterator.PrintIteration(o, 0, spaceForDatetime);
            }
            else
            {
                PrintOut("", msgPrompt, false);
                PrintOut_File(timestamp + ":  ", msgPrompt);
                PropertiesIterator.PrintIteration(o, 0, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void PrintException(string msg)
        {
            var timestamp = DateTime.Now.ToString(datetimestyle);

            if (checkBox_ShowLogTime.Checked)
            {
                PrintOut(timestamp + ":  ", msg, true);
            }
            else
            {
                PrintOut("", msg, true);
            }

            PrintOut_File(timestamp + ":  ", msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_CommandInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string input = "";

                if (e.KeyCode == Keys.Enter)
                {
                    //e.Handled = true;

                    input = comboBox_CommandInput.Text;
                    comboBox_CommandInput.Text = "";

                    if (richTextBox_ConsoleWindow.Text.Length > consoleWindowMaxLength)
                    {
                        richTextBox_ConsoleWindow.Text = new string(richTextBox_ConsoleWindow.Text.Skip(richTextBox_ConsoleWindow.Text.Length - consoleWindowMaxLength).ToArray());
                    }

                    SimpleLogOutput(input);
                }
                else
                {
                    /*
                    if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
                    {
                        //comboBox_CommandInput.SelectionStart = comboBox_CommandInput.Text.Length;
                        //e.Handled = true;
                        comboBox_CommandInput.SelectionStart = 0;
                    }
                    */
                    return;
                }

                //check if it is empty string[]
                if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length == 0)
                {
                    throw new Exception("Empty Input");
                }

                // get string array
                string[] info = TextParser.GetSplittedStringArray(input);

                if (Preprocessing.AnalyzeCommandMode(ref info, checkBox_EnableDefaultMode.Checked))
                {
                    SimpleLogOutput("(Default Mode)");
                }

                // get cmd name, sequence number, payload
                var cmdName = Preprocessing.GetCommandName(info);
                var seq = Preprocessing.GetSequenceNum(info);
                var payload = Preprocessing.GetPayload(info, DeviceInfo.CurrentDevice);

                //build the command
                var bytes = CommandBuilder.Build(cmdName, seq, payload, DeviceInfo.CurrentDevice);

                //send the command on interface
                link.Send(Metocean.iBCNLinkLayer.Wrapper.LinkLayerWrapper.WrapApplicationLayerMessage(bytes.Body));

                //cmd sent, print it;

                #region old output
                /*
                var cmdSentPrompt = "*** Command Sent ***";
                if (checkBox_ShowLogTime.Checked)
                {
                    PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", cmdSentPrompt, false);
                    PropertiesIterator.PrintIteration(bytes, 0, spaceForDatetime);
                }
                else
                {
                    PrintOut("", cmdSentPrompt, false);
                    PropertiesIterator.PrintIteration(bytes, 0, "");
                }
                */

                #endregion

                AdvancedLogOutput(bytes, "*** Command Sent ***");
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //pop up a window to select a port to open

                var p = new Ports();
                var r = p.ShowDialog(this);

                if (r != DialogResult.OK)
                {
                    return;
                }

                if (string.IsNullOrEmpty(p.PortName))
                {
                    MessageBox.Show(this, "No port is selected", "Message", MessageBoxButtons.OK);
                    return;
                }

                link = new SerialLink();

                link.AppDataBytesHandler += (bytes) =>
                {
                    var msgPrompt = "*** Message Received ***";
                    var msg = MessageBuilder.GetMessage(bytes);

                    try
                    {
                        #region old output
                        /*
                        if (checkBox_ShowLogTime.Checked)
                        {
                            PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", msgPrompt, false);
                            PropertiesIterator.PrintIteration(msg, 0, spaceForDatetime);
                        }
                        else
                        {
                            PrintOut("", msgPrompt, false);
                            PropertiesIterator.PrintIteration(msg, 0, "");
                        }
                        */
                        #endregion

                        AdvancedLogOutput(msg, msgPrompt);

                    }
                    catch (Exception ex)
                    {
                        PrintException(ex.Message);
                    }
                };

                link.InvalidAppDataBytesHandler += (bytes) =>
                {
                    var invalidMsgPrompt = "*** Invalid Message Received ***";
                    var msg = "";

                    try
                    {
                        #region old output
                        /*
                        var timestamp = DateTime.Now.ToString(datetimestyle);
                        if (checkBox_ShowLogTime.Checked)
                        {
                            PrintOut(timestamp + ":  ", invalidMsgPrompt, true);
                            //PropertiesIterator.PrintIteration(msg, 0, "                   ");
                        }
                        else
                        {
                            PrintOut("", invalidMsgPrompt, true);
                            //PropertiesIterator.PrintIteration(msg, 0, "");
                        }

                        PrintOut_File(timestamp, invalidMsgPrompt);
                        */
                        #endregion

                        SimpleLogOutput(invalidMsgPrompt);
                    }
                    catch (Exception ex)
                    {
                        PrintException(ex.Message);
                    }
                };

                link.PlainTextBytesHandler += (bytes) =>
                {
                    var plainTextPrompt = "*** Plain Text Received ***";
                    var msg = Encoding.ASCII.GetString(bytes);

                    try
                    {
                        if (checkBox_ShowDiagnosticMsg.Checked)
                        {
                            #region old output
                            /*
                            var timestamp = DateTime.Now.ToString(datetimestyle);

                            if (checkBox_ShowLogTime.Checked)
                            {
                                PrintOut(timestamp + ":  ", plainTextPrompt, false);
                                //PropertiesIterator.PrintIteration(msg, 0, "                   ");
                            }
                            else
                            {
                                PrintOut("", plainTextPrompt, false);
                                //PropertiesIterator.PrintIteration(msg, 0, "");
                            }

                            PrintOut_File(timestamp + ":  ", plainTextPrompt);
                            */
                            #endregion

                            //AdvancedLogOutput(msg, plainTextPrompt);
                            SimpleLogOutput(msg);
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintException(ex.Message);
                    }
                };

                link.NoneStringDetectedHandler += (bytes) =>
                {
                    var msg = "";

                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        PrintException(ex.Message);
                    }
                };

                var portName = p.PortName;
                link.Open(portName);

                openPortToolStripMenuItem.Enabled = false;
                closePortToolStripMenuItem.Enabled = true;

                SimpleLogOutput(portName + " is open");
                comboBox_CommandInput.Enabled = true;
                tooStripStatusLabel_Com.Text = portName;
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                link.Close();
                link = null;

                openPortToolStripMenuItem.Enabled = true;
                closePortToolStripMenuItem.Enabled = false;

                comboBox_CommandInput.Enabled = false;
                tooStripStatusLabel_Com.Text = "Not Connected";
                SimpleLogOutput("Port is close");
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLogDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists("log"))
                {
                    Directory.CreateDirectory("log");
                }

                System.Diagnostics.Process.Start(@"log");
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closePortToolStripMenuItem.Enabled)
            {
                closePortToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
