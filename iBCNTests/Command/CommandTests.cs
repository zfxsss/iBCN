using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metocean.iBCN.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metocean.iBCN.Command.Definition;

namespace Metocean.iBCN.Command.Tests
{
    [TestClass()]
    public class CommandTests
    {
        [TestMethod()]
        public void CommandTest()
        {

        }

        [TestMethod()]
        public void GetCommandBytesTest()
        {
            var bytes = Command<ClearMemoryLog>.GetCommandBytes(1);
            Assert.IsTrue(bytes.Body.Length == 3);
            Assert.IsTrue(bytes.Body[0] == 0x09 && bytes.Body[1] == 0x30 && bytes.Body[2] == 1);
        }

        [TestMethod()]
        public void GetCommandTest()
        {
            var cmd = Command<ClearMemoryLog>.GetCommand(1);
            Assert.IsTrue(cmd.CmdTypeCode == 0x09);
            Assert.IsTrue(cmd.SubCmdTypeCode == 0x30);
            Assert.IsTrue(cmd.Sequence == 1);
        }

        [TestMethod()]
        public void GetCommandTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCommandBytesTest1()
        {
            Assert.Fail();
        }
    }
}