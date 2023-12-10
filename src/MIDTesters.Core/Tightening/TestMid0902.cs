using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTesters.Core.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0902 : MidTester
    {

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0902Revision1()
        {
            string package = "01450902001         000000213400000000012022-12-21:13:02:3300000058192023-12-10:12:28:54002000050010600000001000100190500000002023-11-09:18:48:14";
            var mid = _midInterpreter.Parse<Mid0902>(package);

            Assert.AreEqual(typeof(Mid0902), mid.GetType());
            Assert.AreNotEqual(0, mid.Capacity);
            Assert.AreNotEqual(0, mid.OldestSequenceNumber);
            Assert.IsNotNull(mid.OldestTime);
            Assert.AreNotEqual(0, mid.NewestSequenceNumber);
            Assert.IsNotNull(mid.NewestTime);
            Assert.AreNotEqual(0, mid.NumberOfPIDs);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreNotEqual(0, mid.VariableDataFields.Count);
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
            Assert.AreNotEqual(0, mid.Capacity);
            Assert.AreNotEqual(0, mid.OldestSequenceNumber);
            Assert.IsNotNull(mid.OldestTime);
            Assert.AreNotEqual(0, mid.NewestSequenceNumber);
            Assert.IsNotNull(mid.NewestTime);
            Assert.AreNotEqual(0, mid.NumberOfPIDs);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreNotEqual(0, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }
    }
}
