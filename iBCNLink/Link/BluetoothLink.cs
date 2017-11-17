using Metocean.iBCNLinkLayer.Link.Interface;
using Metocean.iBCNLinkLayer.MsgQueueEngine;
using Metocean.iBCNLinkLayer.Wrapper;
using Metocean.iBCNLinkLayer.MsgQueue;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metocean.iBCN.Message;

namespace Metocean.iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public class BluetoothLink : iBCNLink, ILink
    {
        /// <summary>
        /// 
        /// </summary>
        private const int BaudRate = 9600;

        /// <summary>
        /// 
        /// </summary>
        private byte[] readBuffer = new byte[] { };

        /// <summary>
        /// 
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// 
        /// </summary>
        public bool IsQueueSupported { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Action<byte[]> AppDataPreparedHandler;

        /// <summary>
        /// 
        /// </summary>
        public Action<byte[]> QueueAppDataHandler_Inbound;

        /// <summary>
        /// 
        /// </summary>
        public Action<byte[]> QueueAppDataHandler_Outbound;

        /// <summary>
        /// 
        /// </summary>
        private System.Timers.Timer readTimer;

        /// <summary>
        /// 
        /// </summary>
        private object timerCallbackMutex = new object();

        /// <summary>
        /// 
        /// </summary>
        private bool callbackIsRunning = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public override void Open(string name, bool supportQueue)
        {
            if (serialPort == null)
            {
                AppDataPreparedHandler = (bytes) =>
                {
                    var msg = MessageBuilder.GetMessage(bytes);
                    foreach (var x in msg.GetType().GetProperties())
                    {
                        if (x.Name == "EntityBytes")
                        {
                            var rawbytes = (byte[])x.GetValue(msg);
                            string bytesStr = "";
                            foreach (var b in rawbytes)
                            {
                                bytesStr += b;
                                bytesStr += " ";
                            }
                            Console.WriteLine("EntityBytes : " + bytesStr);
                        }
                        else if (x.Name == "MessageEntity")
                        {
                            try
                            {
                                Console.WriteLine("MessageEntity : ");
                                foreach (var y in x.PropertyType.GetProperties())
                                {
                                    if (!y.PropertyType.IsValueType)
                                    {
                                        Console.WriteLine("  " + y.Name + " : ");
                                        foreach (var z in y.PropertyType.GetProperties())
                                        {
                                            Console.WriteLine("    " + z.Name + " : " + z.GetValue(y.GetValue(x.GetValue(msg))));
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("  " + y.Name + " : " + y.GetValue(x.GetValue(msg)));
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            Console.WriteLine(x.Name + " : " + x.GetValue(msg));
                        }
                    }
                };

                serialPort = new SerialPort(name, BaudRate, Parity.None, 8, StopBits.One);
                serialPort.ReadTimeout = 450;

                readTimer = new System.Timers.Timer(500); // to modify later
                readTimer.AutoReset = true; //false; //true;
                readTimer.Elapsed += (o, e) =>
                {
                    try
                    {
                        lock (timerCallbackMutex)
                        {
                            if (callbackIsRunning)
                            {
                                return;
                            }
                            callbackIsRunning = true;
                        }

                        byte[] tempbuffer = new byte[4096];

                        var readBytesNumber = 0;

                        try
                        {
                            readBytesNumber = serialPort.Read(tempbuffer, 0, serialPort.BytesToRead);
                        }
                        catch (Exception ex)
                        {
                            if (ex is TimeoutException)
                            {
                                readBytesNumber = 0;
                            }
                            else
                            {
                                throw ex;
                            }
                        }


                        readBuffer = readBuffer.Concat(tempbuffer.Take(readBytesNumber)).ToArray();

                        if (readBuffer.Length > 0)
                        {
                            byte[] appMsg;
                            int parseLength;

                            var bytesType = LinkLayerWrapper.ParseLinkLayerBytes(readBuffer, out appMsg, out parseLength);
                            if (bytesType == LinkLayerBytesType.iBCNMsg)
                            {
                                if (supportQueue)
                                {
                                    if (QueueAppDataHandler_Inbound == null)
                                    {
                                        throw new Exception("");
                                    }

                                    Engine.EnqueInBoundMsg(new QueueItem(appMsg, QueueAppDataHandler_Inbound));
                                }
                                else
                                {
                                    AppDataPreparedHandler?.Invoke(appMsg); //invoke the handler
                                }

                                readBuffer = readBuffer.Skip(parseLength).ToArray();
                            }
                            else if (bytesType == LinkLayerBytesType.iBCNMsg_Invalid)
                            {
                                readBuffer = readBuffer.Skip(parseLength).ToArray();
                                Console.WriteLine("iBCNMsg_Invalid detected and processed");
                            }
                            else if (bytesType == LinkLayerBytesType.PlainText)
                            {
                                readBuffer = readBuffer.Skip(parseLength).ToArray();
                                Console.WriteLine("PlainText detected and processed");
                            }
                            else if (bytesType == LinkLayerBytesType.None)
                            {
                                Console.WriteLine("\"None\" string detected");
                            }
                        }


                        if (supportQueue)
                        {
                            QueueAppDataHandler_Outbound = data => Send(data);
                        }

                        lock (timerCallbackMutex)
                        {
                            callbackIsRunning = false;
                        }

                    }
                    catch (Exception)
                    {
                        lock (timerCallbackMutex)
                        {
                            callbackIsRunning = false;
                        }

                        //how to deal with the exception

                    }
                };

                serialPort.Open();
                readTimer.Start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            if (!serialPort.IsOpen)
            {
                throw new Exception("");
            }

            readTimer.Stop();
            readTimer.Close();
            serialPort.Close();
            serialPort = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            if (!serialPort.IsOpen)
            {
                throw new Exception("");
            }
            serialPort.Write(data, 0, data.Length);
        }
    }
}
