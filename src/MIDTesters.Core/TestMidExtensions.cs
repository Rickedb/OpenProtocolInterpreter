using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Communication;
using System;

namespace MIDTesters
{
    [TestClass]
    [TestCategory("Extensions")]
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
            Assert.AreEqual(Mid0002.MID, mid0002.Header.Mid);
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
        public void TestGetAcknowledge()
        {
            var mid0072 = new Mid0071().GetAcknowledge();
            Assert.IsNotNull(mid0072);
            Assert.AreEqual(Mid0072.MID, mid0072.Header.Mid);
        }

        [TestMethod]
        public void TestGetAcknowledgeKeepsRevision()
        {
            var mid0071 = new Mid0071();
            mid0071.Header.Revision = 2;
            Assert.AreEqual(2, mid0071.GetAcknowledge().Header.Revision);
        }

        [TestMethod]
        public void TestGetAcceptCommand()
        {
            var mid0005 = new Mid0003().GetAcceptCommand();
            Assert.IsNotNull(mid0005);
            Assert.AreEqual(Mid0005.MID, mid0005.Header.Mid);
            Assert.AreEqual(Mid0003.MID, mid0005.MidAccepted);
            Assert.AreEqual(Mid0003.MID, ((Mid0005)new Mid0005().Parse(mid0005.Pack())).MidAccepted);
        }

        [TestMethod]
        public void TestGetDeclineCommand()
        {
            var error = Error.ClientAlreadyConnected;
            var mid0004 = new Mid0001().GetDeclineCommand(error);
            Assert.IsNotNull(mid0004);
            Assert.AreEqual(Mid0004.MID, mid0004.Header.Mid);
            Assert.AreEqual(Mid0001.MID, mid0004.FailedMid);
            Assert.AreEqual(mid0004.ErrorCode, error);
        }

        [TestMethod]
        public void TestAssertAndGetDeclineCommand()
        {
            var error = Error.ClientAlreadyConnected;
            var mid0004 = new Mid0001().AssertAndGetDeclineCommand(error);
            Assert.IsNotNull(mid0004);
            Assert.AreEqual(Mid0001.MID, mid0004.FailedMid);
            Assert.AreEqual(mid0004.ErrorCode, error);
        }

        [TestMethod]
        public void TestAssertAndGetDeclineCommandWithNonDocumentedError()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var error = Error.CalibrationFailed;
                var mid0004 = new Mid0001().AssertAndGetDeclineCommand(error);
            });
        }
    }
}
