using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Core.Tool
{
    [TestClass]
    public class TestMid0703 : DefaultMidTests<Mid0703>
    {
        [TestMethod]
        public void Mid0701Revision1()
        {
            string package = "01050703001         0100400301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            var mid = _midInterpreter.Parse<Mid0703>(package);

            Assert.IsNotNull(mid.CalibrationParameters);
            Assert.AreEqual(3, mid.NumberOfCalibrationParameters);
            Assert.AreEqual(40, mid.ToolNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0701ByteRevision1()
        {
            string package = "01050703001         0100400301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0703>(bytes);

            Assert.IsNotNull(mid.CalibrationParameters);
            Assert.AreEqual(3, mid.NumberOfCalibrationParameters);
            Assert.AreEqual(40, mid.ToolNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
