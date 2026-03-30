using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.Core.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid2506 : DefaultMidTests<Mid2506>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid2506Revision1()
        {
            string package = "00272506001         0030201";
            var mid = _midInterpreter.Parse<Mid2506>(package);

            Assert.AreEqual(30, mid.ProgramId);
            Assert.AreEqual(NodeType.MultistepTighteningProgram, mid.NodeType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid2506ByteRevision1()
        {
            string package = "00272506001         0030201";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid2506>(bytes);

            Assert.AreEqual(30, mid.ProgramId);
            Assert.AreEqual(NodeType.MultistepTighteningProgram, mid.NodeType);
            AssertEqualPackages(bytes, mid);
        }
    }
}
