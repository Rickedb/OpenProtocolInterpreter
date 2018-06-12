using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0111 : MidTester
    {
        [TestMethod]
        public void Mid0111Revision1()
        {
            string package = "01370111001         01200502103Header Text              04Line 2 Text              05Line 3 Text              06Line 4 Text              ";
            var mid = _midInterpreter.Parse<MID_0111>(package);

            Assert.AreEqual(typeof(MID_0111), mid.GetType());
            Assert.IsNotNull(mid.TextDuration);
            Assert.IsNotNull(mid.RemovalCondition);
            Assert.IsNotNull(mid.Line1);
            Assert.IsNotNull(mid.Line2);
            Assert.IsNotNull(mid.Line3);
            Assert.IsNotNull(mid.Line4);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
