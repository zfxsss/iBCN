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
            Definition.Interface.ICmdBytes x = new Definition.ClearMemoryLog();
            var y = (Definition.Interface.ICmdBytes)(new Definition.ClearMemoryLog());

            Console.WriteLine("Type is:" + x.GetType().ToString());
            Console.WriteLine("Type is:" + y.GetType().ToString());

            Assert.Fail();
        }

        [TestMethod()]
        public void GetCommandBytesTest()
        {
            Command<ClearMemoryLog>.GetCommandBytes();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCommandTest()
        {
            Command<ClearMemoryLog>.GetCommand();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCommandTest1()
        {
            Assert.Fail();
        }
    }
}