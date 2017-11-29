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

            foreach (var c in Preprocessing.CommandSupported)
            {
                comboBox_CommandInput.Items.Add(c);
            }

            comboBox_CommandInput.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_CommandInput.AutoCompleteMode = AutoCompleteMode.Suggest;

            PropertiesIterator.CB += (prefixMsg, msg) =>
            {
                PrintOut(prefixMsg, msg, false);
            };

            //when a command is built, callback will be invoked
            CommandBuilder.CB += (o) =>
            {
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
            };

            spaceForDatetime = "";
            for (int i = 0; i < 50; i++)
            {
                spaceForDatetime += " ";
            }
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
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void PrintException(string msg)
        {
            if (checkBox_ShowLogTime.Checked)
            {
                PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", msg, true);
            }
            else
            {
                PrintOut("", msg, true);
            }
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

                    if (checkBox_ShowLogTime.Checked)
                    {
                        PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", input, false);
                    }
                    else
                    {
                        PrintOut("", input, false);
                    }
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
                    if (checkBox_ShowLogTime.Checked)
                    {
                        PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", "(Default Mode)", false);
                    }
                    else
                    {
                        PrintOut("", "(Default Mode)", false);
                    }
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
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //pop up a window to select a port to open




                link = new SerialLink();

                link.AppDataBytesHandler += (bytes) =>
                {
                    var msgPrompt = "*** Message Received ***";
                    var msg = MessageBuilder.GetMessage(bytes);
                    try
                    {
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
                        if (checkBox_ShowLogTime.Checked)
                        {
                            PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", invalidMsgPrompt, true);
                            //PropertiesIterator.PrintIteration(msg, 0, "                   ");
                        }
                        else
                        {
                            PrintOut("", invalidMsgPrompt, true);
                            //PropertiesIterator.PrintIteration(msg, 0, "");
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintException(ex.Message);
                    }
                };

                link.PlainTextBytesHandler += (bytes) =>
                {
                    var plainTextPrompt = "*** Plain Text Received ***";
                    var msg = "";

                    try
                    {
                        if (checkBox_ShowDiagnosticMsg.Checked)
                        {
                            if (checkBox_ShowLogTime.Checked)
                            {
                                PrintOut(DateTime.Now.ToString(datetimestyle) + ":  ", plainTextPrompt, false);
                                //PropertiesIterator.PrintIteration(msg, 0, "                   ");
                            }
                            else
                            {
                                PrintOut("", plainTextPrompt, false);
                                //PropertiesIterator.PrintIteration(msg, 0, "");
                            }
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

                link.Open("COM3");
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
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
        }

    }
}
