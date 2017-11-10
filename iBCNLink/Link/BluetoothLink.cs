using iBCNLinkLayer.Link.Interface;
using iBCNLinkLayer.MsgQueueEngine;
using iBCNLinkLayer.Wrapper;
using iBCNLinkLayer.MsgQueue;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iBCNLinkLayer.Link
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
        private int bufferCursor = 0;

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
                serialPort = new SerialPort(name, BaudRate, Parity.None, 8, StopBits.One);
                serialPort.ReadTimeout = 450;

                readTimer = new System.Timers.Timer(500);
                readTimer.AutoReset = true;
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

                        if (readBytesNumber > 0)
                        {
                            readBuffer = readBuffer.Concat(tempbuffer.Take(readBytesNumber)).ToArray();
                            while (bufferCursor < readBuffer.Length)
                            {
                                byte[] appMsg;
                                if (LinkLayerWrapper.UnwrapLinkLayerMessage(readBuffer.Take(bufferCursor + 1).ToArray(), out appMsg))
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
                                    readBuffer = readBuffer.Skip(bufferCursor + 1).ToArray();
                                    bufferCursor = 0;
                                    break;
                                }

                                bufferCursor++;
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

            bufferCursor = 0;
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
