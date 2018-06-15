using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0222 : MidTester
    {
        [TestMethod]
        public void Mid0222Revision1()
        {
            string package = "00200222            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0222), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
