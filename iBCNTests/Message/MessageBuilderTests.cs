using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metocean.iBCN.Message.Entity;

namespace Metocean.iBCN.Message.Tests
{
    [TestClass()]
    public class MessageBuilderTests
    {
        [TestMethod()]
        public void GetMessageTest()
        {
            var x = MessageBuilder.GetMessage(new byte[] { 0x01, 0x81 });

            var y = (Interface.IMsg<EventReport>)x;

            var z = (Msg<EventReport>)x;

            var h = (Interface.IMsg<EventReport>)((Msg<EventReport>)x);

            var o = (object)x;
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetMessageEntityTest()
        {
            var x = MessageBuilder.GetMessageEntity(new byte[] { 0x01, 0x81, 0x00, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04, 0x01, 0x02, 0x03, 0x04 });
            var y = x.ToString();

            var z = (iBCNMessage)x;
            var k = z.ToString();

            //Assert.Fail();
        }
    }
}