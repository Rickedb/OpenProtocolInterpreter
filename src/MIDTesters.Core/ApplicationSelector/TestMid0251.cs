using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;
using System.Collections.Generic;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0251 : DefaultMidTests<Mid0251>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0251Revision1()
        {
            string package = "00400251   1        01500210030101101110";
            var mid = _midInterpreter.Parse<Mid0251>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.AreEqual(50, mid.DeviceId);
            Assert.AreEqual(10, mid.NumberOfSockets);
            CollectionAssert.AreEqual(new List<bool>
            {
                false,
                true,
                false,
                true,
                true,
                false,
                true,
                true,
                true,
                false
            }, mid.SocketStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0251ByteRevision1()
        {
            string package = "00400251   1        01500210030101101110";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0251>(bytes);

            Assert.AreEqual(50, mid.DeviceId);
            Assert.AreEqual(10, mid.NumberOfSockets);
            CollectionAssert.AreEqual(new List<bool>
            {
                false,
                true,
                false,
                true,
                true,
                false,
                true,
                true,
                true,
                false
            }, mid.SocketStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
