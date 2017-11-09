using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialPortAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sp = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
            sp.ReadTimeout = 1000;
            sp.Open();
            var buffer = new byte[8];
            sp.Read(buffer, 0, sp.BytesToRead);

            sp.Write("abcd");
            /*
            sp.DataReceived += (o, e) =>
             {
                 var buffer = new byte[8];
                 var spDR = (SerialPort)o;

                 spDR.Read(buffer, 0, spDR.BytesToRead);

             };
             */
            sp.Close();
        }
    }
}
