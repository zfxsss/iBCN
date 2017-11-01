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
    }
}