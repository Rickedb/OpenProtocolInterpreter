using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Core.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0704 : DefaultMidTests<Mid0704>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0704Revision1()
        {
            string package = "00700704001         00201200012040000000QST50-150CTT012150010200000003";
            var mid = _midInterpreter.Parse<Mid0704>(package);

            Assert.AreNotEqual(0, mid.NumberOfDataFields);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreNotEqual(0, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0704ByteRevision1()
        {
            string package = "00700704001         00201200012040000000QST50-150CTT012150010200000003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0704>(bytes);

            Assert.AreNotEqual(0, mid.NumberOfDataFields);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreNotEqual(0, mid.VariableDataFields.Count);
            AssertEqualPackages(bytes, mid);
        }
    }
}
