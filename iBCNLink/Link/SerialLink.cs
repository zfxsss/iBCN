using Metocean.iBCNLinkLayer.Link.Interface;
using Metocean.iBCNLinkLayer.Wrapper;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialLink : iBCNLink, ILink
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
        public event Action<byte[]> AppDataBytesHandler;

        /// <summary>
        /// 
        /// </summary>
        public event Action<byte[]> InvalidAppDataBytesHandler;

        /// <summary>
        /// 
        /// </summary>
        public event Action<byte[]> PlainTextBytesHandler;

        /// <summary>
        /// 
        /// </summary>
        public event Action<byte[]> NoneStringDetectedHandler;

        /// <summary>
        /// 
        /// </summary>
        public event Action<Exception> ExceptionHandler;

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
        public override void Open(string name)
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort(name, BaudRate, Parity.None, 8, StopBits.One);
                serialPort.ReadTimeout = 500; // can be modified
                serialPort.WriteTimeout = 1500; // can be modified

                readTimer = new System.Timers.Timer(750); // can be modified
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

                        byte[] tempbuffer = new byte[serialPort.ReadBufferSize]; //in default the length is 4096

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
                            while (1 == 1)
                            {
                                byte[] appMsg;
                                int parseLength;

                                var bytesType = LinkLayerWrapper.ParseLinkLayerBytes(readBuffer, out appMsg, out parseLength);
                                if (bytesType == LinkLayerBytesType.iBCNMsg)
                                {
                                    AppDataBytesHandler?.Invoke(appMsg); //invoke the handler
                                    readBuffer = readBuffer.Skip(parseLength).ToArray();
                                }
                                else if (bytesType == LinkLayerBytesType.iBCNMsg_Invalid)
                                {
                                    InvalidAppDataBytesHandler?.Invoke(appMsg);
                                    readBuffer = readBuffer.Skip(parseLength).ToArray();
                                    //Console.WriteLine("iBCNMsg_Invalid detected and processed");
                                }
                                else if (bytesType == LinkLayerBytesType.PlainText)
                                {
                                    PlainTextBytesHandler?.Invoke(appMsg);
                                    readBuffer = readBuffer.Skip(parseLength).ToArray();
                                    //Console.WriteLine("PlainText detected and processed");
                                }
                                else if (bytesType == LinkLayerBytesType.None)
                                {
                                    NoneStringDetectedHandler?.Invoke(appMsg);
                                    //Console.WriteLine("\"None\" string detected");
                                    //bytes are not enough
                                    break;
                                }

                                //no bytes anymore
                                if (readBuffer.Length == 0)
                                {
                                    break;
                                }

                            }
                        }

                        lock (timerCallbackMutex)
                        {
                            callbackIsRunning = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        lock (timerCallbackMutex)
                        {
                            callbackIsRunning = false;
                        }

                        //how to deal with the exception
                        ExceptionHandler?.Invoke(ex);
                    }
                };

                //serialPort.Open();
                //readTimer.Start();
            }

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                readTimer.Start();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void PortCheck()
        {
            if (serialPort == null)
            {
                throw new Exception("serialPort is null");
            }

            if (!serialPort.IsOpen)
            {
                throw new Exception("serialPort is not open");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            PortCheck();

            readTimer.Stop();
            readTimer.Close();
            serialPort.Close();

            //set it to null
            serialPort = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            PortCheck();

            serialPort.Write(data, 0, data.Length);
        }

    }
}
