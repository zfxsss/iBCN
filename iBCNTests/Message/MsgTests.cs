using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metocean.iBCN.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metocean.iBCN.Message.Entity;

namespace Metocean.iBCN.Message.Tests
{
    [TestClass()]
    public class MsgTests
    {
        [TestMethod()]
        public void GetMessageEntityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMessageEntityTest1()
        {
            byte x1 = new byte();
            byte[] x2 = new byte[] { 1, 2 };
            byte[] x3 = new byte[] { };

            Console.WriteLine(x1.GetType().Name);
            Console.WriteLine(x3.GetType().Name);

            Array.Resize(ref x3, 10);
            var l = x3.Length;
            var x5 = new StartDownload();
            Console.WriteLine(x5.GetType().Name);

            var x6 = new RecordsPacket();
            Console.WriteLine(x6.Records.GetType().Name);

            Console.WriteLine(sizeof(UInt16));

            //Assert.Fail();
        }
    }
}