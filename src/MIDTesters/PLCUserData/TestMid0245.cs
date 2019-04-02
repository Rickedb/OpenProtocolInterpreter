using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0245 : MidTester
    {
        [TestMethod]
        public void Mid0245Revision1()
        {
            string package = "00460245            022My identifier less than";
            var mid = _midInterpreter.Parse<Mid0245>(package);

            Assert.AreEqual(typeof(Mid0245), mid.GetType());
            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0245ByteRevision1()
        {
            string package = "00460245            022My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0245>(bytes);

            Assert.AreEqual(typeof(Mid0245), mid.GetType());
            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
