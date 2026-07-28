using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Vin;
using System.Linq;

namespace MIDTesters.Vin
{
    [TestClass]
    [TestCategory("Vin")]
    public class TestMid0052 : DefaultMidTests<Mid0052>
    {

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0052Revision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual("VehicleIdNumberHigherThan25", mid.VinNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0052ByteRevision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual("VehicleIdNumberHigherThan25", mid.VinNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0052Revision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          \0";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual("VehicleIdNumber", mid.VinNumber.TrimEnd('\0', ' '));
            mid.Header.StationId = mid.Header.SpindleId = null;
            Assert.AreEqual(package, mid.PackWithNul());
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0052ByteRevision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          \0";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual("VehicleIdNumber", mid.VinNumber.TrimEnd('\0', ' '));
            mid.Header.StationId = mid.Header.SpindleId = null;
            Assert.IsTrue(mid.PackBytesWithNul().SequenceEqual(bytes));
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0052Revision2()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual("VehicleIdNumber", mid.VinNumber.TrimEnd());
            Assert.AreEqual("IdentifierPart2", mid.IdentifierResultPart2.TrimEnd());
            Assert.AreEqual("IdentifierPart3", mid.IdentifierResultPart3.TrimEnd());
            Assert.AreEqual("IdentifierPart4", mid.IdentifierResultPart4.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0052ByteRevision2()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual("VehicleIdNumber", mid.VinNumber.TrimEnd());
            Assert.AreEqual("IdentifierPart2", mid.IdentifierResultPart2.TrimEnd());
            Assert.AreEqual("IdentifierPart3", mid.IdentifierResultPart3.TrimEnd());
            Assert.AreEqual("IdentifierPart4", mid.IdentifierResultPart4.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }
    }
}
