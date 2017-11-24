using Microsoft.VisualStudio.TestTools.UnitTesting;
using iBCNConsole.CommandText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNConsole.Text.Tests
{
    [TestClass()]
    public class TextParserTests
    {
        [TestMethod()]
        public void GetSplittedStringArrayTest()
        {
            var x = TextParser.GetSplittedStringArray("  set  2    gdfgdfg      we  ");

            Assert.IsTrue(x[0] == "set");
        }
    }
}