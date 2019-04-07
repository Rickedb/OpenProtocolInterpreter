using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0052 : MidTester
    {

        [TestMethod]
        public void Mid0052Revision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0052ByteRevision1VehicleIdLengthHigher()
        {
            string package = "00470052001         VehicleIdNumberHigherThan25";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0052Revision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0052ByteRevision1VehicleIdLengthLower()
        {
            string package = "00450052001         VehicleIdNumber          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0052Revision2VehicleIdLengthHigher()
        {
            string package = "01300052002         01VehicleIdNumberHigherThan2502IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0052ByteRevision2VehicleIdLengthHigher()
        {
            string package = "01300052002         01VehicleIdNumberHigherThan2502IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0052Revision2VehicleIdLengthLower()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            var mid = _midInterpreter.Parse<Mid0052>(package);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0052ByteRevision2VehicleIdLengthLower()
        {
            string package = "01280052002         01VehicleIdNumber          02IdentifierPart2          03IdentifierPart3          04IdentifierPart4          ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0052>(bytes);

            Assert.AreEqual(typeof(Mid0052), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
