using iBCNLinkLayer.Link.Interface;
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
        private const int BaudRate = 19200;

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
        public Action<byte[]> QueueAppDataHandler;

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
                serialPort = new SerialPort(name, BaudRate, Parity.None, 8, StopBits.None);
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
                        var readBytesNumber = serialPort.Read(tempbuffer, 0, serialPort.BytesToRead);

                        if (readBytesNumber > 0)
                        {
                            readBuffer = readBuffer.Concat(tempbuffer.Take(readBytesNumber)).ToArray();
                            while (bufferCursor < readBuffer.Length)
                            {
                                if (1 == 1)
                                {
                                    bufferCursor = 0;
                                    break;
                                }

                                bufferCursor++;
                            }


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
    }
}
