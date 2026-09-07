using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Core.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0900 : DefaultMidTests<Mid0900>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0900ByteRevision1()
        {
            byte[] package = BuildWire(1);
            var mid = _midInterpreter.Parse<Mid0900>(package);

            Assert.AreEqual(typeof(Mid0900), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(3, mid.NumberOfSamples);
            CollectionAssert.AreEqual(new short[] { 100, -200, 300 }, mid.TraceSamples);
            // Round-trip against the fixture (spaces in station/spindle). Do not use
            // PackBytes() as the expected side before nulling those header fields.
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0900ByteRevision2()
        {
            byte[] package = BuildWire(2);
            var mid = _midInterpreter.Parse<Mid0900>(package);

            Assert.AreEqual(typeof(Mid0900), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(9001, mid.RequestMid);
            Assert.AreEqual(3, mid.NumberOfSamples);
            CollectionAssert.AreEqual(new short[] { 100, -200, 300 }, mid.TraceSamples);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0900ByteRevision3()
        {
            byte[] package = BuildWire(3);
            var mid = _midInterpreter.Parse<Mid0900>(package);

            Assert.AreEqual(typeof(Mid0900), mid.GetType());
            AssertCommonFields(mid);
            Assert.AreEqual(9001, mid.RequestMid);
            Assert.AreEqual(1234, mid.ObjectId);
            Assert.AreEqual(ObjectType.TighteningProduction, mid.ObjectType);
            Assert.AreEqual(5678, mid.ReferenceObjectId);
            Assert.AreEqual(3, mid.NumberOfTraces);
            Assert.AreEqual(3, mid.NumberOfSamples);
            CollectionAssert.AreEqual(new short[] { 100, -200, 300 }, mid.TraceSamples);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0900AsciiRevision1ParsesLeadOnly()
        {
            // ASCII Parse cannot carry the binary tail; it must still parse the lead fields.
            string asciiLead = Encoding.ASCII.GetString(BuildWire(1)).Split('\0')[0];
            // Rebuild a pure-ASCII package with length = ascii lead only (no NUL/samples in length).
            var body = asciiLead.Substring(20);
            string package = (20 + body.Length).ToString("D4") + asciiLead.Substring(4);
            var mid = _midInterpreter.Parse<Mid0900>(package);

            Assert.AreEqual("RDI0000001", mid.ResultDataIdentifier);
            Assert.AreEqual(2, mid.NumberOfPIDs);
            Assert.AreEqual(2, mid.TraceType);
            Assert.AreEqual(3, mid.NumberOfSamples);
        }

        private static void AssertCommonFields(Mid0900 mid)
        {
            Assert.AreEqual("RDI0000001", mid.ResultDataIdentifier);
            Assert.AreEqual(2, mid.NumberOfPIDs);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            Assert.AreEqual(105, mid.VariableDataFields[0].ParameterId);
            Assert.AreEqual("25.5", mid.VariableDataFields[0].DataValue);
            Assert.AreEqual(2, mid.TraceType);
            Assert.AreEqual(1, mid.TransducerType);
            Assert.AreEqual(1, mid.Unit);
            Assert.AreEqual(1, mid.NumberOfParameterDataFields);
            Assert.AreEqual(1, mid.ParameterDataFields.Count);
            Assert.AreEqual(200, mid.ParameterDataFields[0].ParameterId);
            Assert.AreEqual(1, mid.NumberOfResolutionFields);
            Assert.AreEqual(1, mid.ResolutionFields.Count);
            Assert.AreEqual(0, mid.ResolutionFields[0].FirstIndex);
            Assert.AreEqual(2, mid.ResolutionFields[0].LastIndex);
            Assert.AreEqual("10", mid.ResolutionFields[0].TimeValue);
        }

        private static string Vdf(int pid, int dtype, int unit, int step, string value)
            => pid.ToString("D5") + value.Length.ToString("D3") + dtype.ToString("D2") + unit.ToString("D3") + step.ToString("D4") + value;

        private static string Res(int first, int last, int dtype, int unit, string timeValue)
            => first.ToString("D5") + last.ToString("D5") + timeValue.Length.ToString("D3") + dtype.ToString("D2") + unit.ToString("D3") + timeValue;

        /// <summary>
        /// Builds a wire-format MID 0900 package matching Spec R 2.21.1 Tables 139–141
        /// (ASCII lead + NUL + big-endian Int16 samples).
        /// </summary>
        private static byte[] BuildWire(int revision)
        {
            var ascii = new StringBuilder();
            // Header tail uses spaces so AssertEqualPackages (which nulls StationId/SpindleId) round-trips.
            ascii.Append("00000900" + revision.ToString("D3") + "         ");
            ascii.Append("RDI0000001");
            ascii.Append("2026-09-07:12:30:00");
            if (revision >= 3) { ascii.Append("1234"); ascii.Append("2"); ascii.Append("5678"); }
            ascii.Append("002");
            ascii.Append(Vdf(105, 1, 1, 1, "25.5"));
            ascii.Append(Vdf(106, 3, 1, 2, "1.25"));
            ascii.Append("02");
            if (revision >= 3) ascii.Append("03");
            ascii.Append("01").Append("001");
            if (revision >= 2) ascii.Append("9001");
            ascii.Append("001");
            ascii.Append(Vdf(200, 1, 0, 0, "7"));
            ascii.Append("001");
            ascii.Append(Res(0, 2, 1, 20, "10"));
            ascii.Append("00003");
            ascii.Append('\0');

            var asciiBytes = Encoding.ASCII.GetBytes(ascii.ToString());
            short[] samples = { 100, -200, 300 };
            var sampleBytes = new List<byte>();
            foreach (var s in samples)
            {
                sampleBytes.Add((byte)(s >> 8));
                sampleBytes.Add((byte)(s & 0xFF));
            }

            int asciiFieldLen = asciiBytes.Length - 20; // includes the NUL
            int lengthField = 20 + asciiFieldLen + (samples.Length * 2);
            Array.Copy(Encoding.ASCII.GetBytes(lengthField.ToString("D4")), 0, asciiBytes, 0, 4);

            var wire = new byte[asciiBytes.Length + sampleBytes.Count];
            Array.Copy(asciiBytes, 0, wire, 0, asciiBytes.Length);
            Array.Copy(sampleBytes.ToArray(), 0, wire, asciiBytes.Length, sampleBytes.Count);
            return wire;
        }
    }
}
