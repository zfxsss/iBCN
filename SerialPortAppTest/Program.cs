using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Metocean.iBCN.Message;

namespace SerialPortAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            //sp.ReadTimeout = 1000;
            //sp.Open();
            //var buffer = new byte[1024];
            //var count = sp.Read(buffer, 0, sp.BytesToRead);

            //sp.Write("abcd");
            /*
            sp.DataReceived += (o, e) =>
             {
                 var buffer = new byte[8];
                 var spDR = (SerialPort)o;

                 spDR.Read(buffer, 0, spDR.BytesToRead);

             };
             */
            //sp.Close();

            var x = MessageBuilder.GetMessageEntity(new byte[] { 0x01, 0x81, 0x00, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04 });

            for (var i = 0; i < 1000000; i++)
            {               
                var y = x.ToString();
                Console.WriteLine(y);
            }
        }
    }
}
