using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Core.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0901 : DefaultMidTests<Mid0901>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0901Revision1()
        {
            string package = BuildPackage(1);
            var mid = _midInterpreter.Parse<Mid0901>(package);

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0901ByteRevision1()
        {
            string package = BuildPackage(1);
            var mid = _midInterpreter.Parse<Mid0901>(GetAsciiBytes(package));

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0901Revision2()
        {
            string package = BuildPackage(2);
            var mid = _midInterpreter.Parse<Mid0901>(package);

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(8, mid.RequestMid);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0901ByteRevision2()
        {
            string package = BuildPackage(2);
            var mid = _midInterpreter.Parse<Mid0901>(GetAsciiBytes(package));

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(8, mid.RequestMid);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0901Revision3()
        {
            string package = BuildPackage(3);
            var mid = _midInterpreter.Parse<Mid0901>(package);

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(8, mid.RequestMid);
            Assert.AreEqual(1234, mid.ObjectId);
            Assert.AreEqual(ObjectType.TighteningProduction, mid.ObjectType);
            Assert.AreEqual(5678, mid.ReferenceObjectId);
            Assert.AreEqual(2, mid.TraceType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0901ByteRevision3()
        {
            string package = BuildPackage(3);
            var mid = _midInterpreter.Parse<Mid0901>(GetAsciiBytes(package));

            Assert.AreEqual(typeof(Mid0901), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(8, mid.RequestMid);
            Assert.AreEqual(1234, mid.ObjectId);
            Assert.AreEqual(ObjectType.TighteningProduction, mid.ObjectType);
            Assert.AreEqual(5678, mid.ReferenceObjectId);
            Assert.AreEqual(2, mid.TraceType);
            AssertEqualPackages(package, mid);
        }

        private static void AssertCommonFields(Mid0901 mid)
        {
            Assert.AreEqual("RDI0000001", mid.ResultDataIdentifier);
            Assert.AreEqual(2, mid.NumberOfPIDs);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            Assert.AreEqual(105, mid.VariableDataFields[0].ParameterId);
            Assert.AreEqual("25.5", mid.VariableDataFields[0].DataValue);
            Assert.AreEqual(106, mid.VariableDataFields[1].ParameterId);
            Assert.AreEqual("1.25", mid.VariableDataFields[1].DataValue);
        }

        private static string Vdf(int pid, int dtype, int unit, int step, string value)
            => pid.ToString("D5") + value.Length.ToString("D3") + dtype.ToString("D2") + unit.ToString("D3") + step.ToString("D4") + value;

        /// <summary>
        /// Builds a wire-format MID 0901 package matching Spec R 2.21.1 Tables 146–148.
        /// </summary>
        private static string BuildPackage(int revision)
        {
            var ascii = new StringBuilder();
            ascii.Append("00000901" + revision.ToString("D3") + "         ");
            ascii.Append("RDI0000001");
            ascii.Append("2026-09-07:12:30:00");
            ascii.Append("002");
            if (revision >= 2) ascii.Append("0008");
            if (revision >= 3)
            {
                ascii.Append("1234");
                ascii.Append("2");
                ascii.Append("5678");
                ascii.Append("02");
            }
            ascii.Append(Vdf(105, 1, 1, 1, "25.5"));
            ascii.Append(Vdf(106, 3, 1, 2, "1.25"));

            string package = ascii.ToString();
            return package.Length.ToString("D4") + package.Substring(4);
        }
    }
}
