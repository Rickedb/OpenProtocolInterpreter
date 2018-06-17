using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0113 : MidTester
    {
        [TestMethod]
        public void Mid0113Revision1()
        {
            string package = "00200113            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0113), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
