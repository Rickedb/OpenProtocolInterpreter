using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using System;

namespace MIDTesters
{
    [TestClass]
    public class TestMidExtensions
    {
        public TestMidExtensions()
        {

        }

        [TestMethod]
        public void TestPack()
        {
            var package = new Mid0001().PackWithNul();
            Assert.IsNotNull(package);
        }

        [TestMethod]
        public void TestPackWithNul()
        {
            var package = new Mid0001().PackWithNul();
            Assert.IsNotNull(package);
            Assert.AreEqual('\0', package[package.Length - 1]);
        }

        [TestMethod]
        public void TestPackBytes()
        {
            var bytes = new Mid0001().PackBytesWithNul();
            Assert.IsNotNull(bytes);
        }

        [TestMethod]
        public void TestPackBytesWithNul()
        {
            var bytes = new Mid0001().PackBytesWithNul();
            Assert.IsNotNull(bytes);
            Assert.AreEqual(0x00, bytes[bytes.Length - 1]);
        }

        [TestMethod]
        public void TestGetReply()
        {
            var mid0002 = new Mid0001().GetReply();
            Assert.IsNotNull(mid0002);
        }

        [TestMethod]
        public void TestGetReplyWithRevision()
        {
            var revision = 3;
            var mid0002 = new Mid0001().GetReply(revision);
            Assert.IsNotNull(mid0002);
            Assert.AreEqual(mid0002.Header.Revision, revision);
        }

        [TestMethod]
        public void TestGetAcceptCommand()
        {
            var mid0005 = new Mid0003().GetAcceptCommand();
            Assert.IsNotNull(mid0005);
        }

        [TestMethod]
        public void TestGetDeclineCommand()
        {
            var error = Error.CLIENT_ALREADY_CONNECTED;
            var mid0004 = new Mid0001().GetDeclineCommand(error);
            Assert.IsNotNull(mid0004);
            Assert.AreEqual(mid0004.ErrorCode, error);
        }

        [TestMethod]
        public void TestAssertAndGetDeclineCommand()
        {
            var error = Error.CLIENT_ALREADY_CONNECTED;
            var mid0004 = new Mid0001().AssertAndGetDeclineCommand(error);
            Assert.IsNotNull(mid0004);
            Assert.AreEqual(mid0004.ErrorCode, error);
        }

        [TestMethod]
        public void TestAssertAndGetDeclineCommandWithNonDocumentedError()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var error = Error.CALIBRATION_FAILED;
                var mid0004 = new Mid0001().AssertAndGetDeclineCommand(error);
            });
        }
    }
}
