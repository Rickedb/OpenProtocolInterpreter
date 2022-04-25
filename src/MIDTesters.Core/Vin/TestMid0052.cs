using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Vin;
using System.Linq;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0052 : DefaultMidTests<Mid0052>
    {

        [TestMethod]
        public void Mid0052Revision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.IsNotNull(mid.VinNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0052ByteRevision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.IsNotNull(mid.VinNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0052Revision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          \0";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.IsNotNull(mid.VinNumber);
            mid.Header.StationID = mid.Header.SpindleID = null;
            Assert.AreEqual(package, mid.PackWithNul());
        }

        [TestMethod]
        public void Mid0052ByteRevision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          \0";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.IsNotNull(mid.VinNumber);
            mid.Header.StationID = mid.Header.SpindleID = null;
            Assert.IsTrue(mid.PackBytesWithNul().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0052Revision2VehicleIdLengthHigher()
        {
            string package = "01300052002         01VehicleIdNumberHigherThan2502IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0052ByteRevision2VehicleIdLengthHigher()
        {
            string package = "01300052002         01VehicleIdNumberHigherThan2502IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0052Revision2VehicleIdLengthLower()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0052ByteRevision2VehicleIdLengthLower()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            AssertEqualPackages(bytes, mid);
        }
    }
}
