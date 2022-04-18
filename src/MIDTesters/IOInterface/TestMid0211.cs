using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0211 : MidTester
    {
        [TestMethod]
        public void Mid0211Revision1()
        {
            string package = "00280211   1        10101011";
            var mid = _midInterpreter.Parse<Mid0211>(package);

            Assert.AreEqual(typeof(Mid0211), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.StatusDigInOne);
            Assert.IsNotNull(mid.StatusDigInTwo);
            Assert.IsNotNull(mid.StatusDigInThree);
            Assert.IsNotNull(mid.StatusDigInFour);
            Assert.IsNotNull(mid.StatusDigInFive);
            Assert.IsNotNull(mid.StatusDigInSix);
            Assert.IsNotNull(mid.StatusDigInSeven);
            Assert.IsNotNull(mid.StatusDigInEight);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0211ByteRevision1()
        {
            string package = "00280211   1        10101011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0211>(bytes);

            Assert.AreEqual(typeof(Mid0211), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.StatusDigInOne);
            Assert.IsNotNull(mid.StatusDigInTwo);
            Assert.IsNotNull(mid.StatusDigInThree);
            Assert.IsNotNull(mid.StatusDigInFour);
            Assert.IsNotNull(mid.StatusDigInFive);
            Assert.IsNotNull(mid.StatusDigInSix);
            Assert.IsNotNull(mid.StatusDigInSeven);
            Assert.IsNotNull(mid.StatusDigInEight);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
