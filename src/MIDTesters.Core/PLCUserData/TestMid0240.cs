using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0240 : MidTester
    {
        [TestMethod]
        public void Mid0240Revision1()
        {
            string package = "00470240            My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0240>(package);

            Assert.AreEqual(typeof(Mid0240), mid.GetType());
            Assert.IsNotNull(mid.UserData);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0240ByteRevision1()
        {
            string package = "00470240            My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0240>(bytes);

            Assert.AreEqual(typeof(Mid0240), mid.GetType());
            Assert.IsNotNull(mid.UserData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
