using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0902 : DefaultMidTests<Mid0902>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0902Revision1()
        {
            string package = "01450902001         000000213400000000012022-12-21:13:02:3300000058192023-12-10:12:28:54002000050010600000001000100190500000002023-11-09:18:48:14";
            var mid = _midInterpreter.Parse<Mid0902>(package);

            Assert.AreEqual(typeof(Mid0902), mid.GetType());
            Assert.AreEqual(2134L, mid.Capacity);
            Assert.AreEqual(1L, mid.OldestSequenceNumber);
            Assert.AreEqual(new DateTime(2022, 12, 21, 13, 2, 33), mid.OldestTime);
            Assert.AreEqual(5819L, mid.NewestSequenceNumber);
            Assert.AreEqual(new DateTime(2023, 12, 10, 12, 28, 54), mid.NewestTime);
            Assert.AreEqual(2, mid.NumberOfPIDs);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0902ByteRevision1()
        {
            string package = "01450902001         000000213400000000012022-12-21:13:02:3300000058192023-12-10:12:28:54002000050010600000001000100190500000002023-11-09:18:48:14";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0902>(bytes);

            Assert.AreEqual(typeof(Mid0902), mid.GetType());
            Assert.AreEqual(2134L, mid.Capacity);
            Assert.AreEqual(1L, mid.OldestSequenceNumber);
            Assert.AreEqual(new DateTime(2022, 12, 21, 13, 2, 33), mid.OldestTime);
            Assert.AreEqual(5819L, mid.NewestSequenceNumber);
            Assert.AreEqual(new DateTime(2023, 12, 10, 12, 28, 54), mid.NewestTime);
            Assert.AreEqual(2, mid.NumberOfPIDs);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }
    }
}
