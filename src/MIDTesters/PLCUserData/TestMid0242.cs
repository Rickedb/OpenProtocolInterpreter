using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0242 : MidTester
    {
        [TestMethod]
        public void Mid0242Revision1()
        {
            string package = "00430242   1        My identifier less than";
            var mid = _midInterpreter.Parse<Mid0242>(package);

            Assert.AreEqual(typeof(Mid0242), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.UserData);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0242ByteRevision1()
        {
            string package = "00430242   1        My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0242>(bytes);

            Assert.AreEqual(typeof(Mid0242), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.UserData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
