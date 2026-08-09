using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid2501 : DefaultMidTests<Mid2501>
    {
        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ASCII")]
        // public void Mid2501Revision1()
        // {
        //     string package = "00272501001         0010001";
        //     var mid = _midInterpreter.Parse<Mid2501>(package);

        //     Assert.AreEqual(10, mid.ProgramId);
        //     Assert.AreEqual(NodeType.ParameterSet, mid.NodeType);
        //     AssertEqualPackages(package, mid);
        // }

        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ByteArray")]
        // public void Mid2501ByteRevision1()
        // {
        //     string package = "00272501001         0010001";
        //     byte[] bytes = GetAsciiBytes(package);
        //     var mid = _midInterpreter.Parse<Mid2501>(bytes);

        //     Assert.AreEqual(10, mid.ProgramId);
        //     Assert.AreEqual(NodeType.ParameterSet, mid.NodeType);
        //     AssertEqualPackages(bytes, mid);
        // }

        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ASCII")]
        // public void Mid2501ExtraDataRevision1()
        // {
        //     string package = "00360006001         2501001070010001";
        //     var mid = _midInterpreter.Parse<Mid0006>(package);
        //     var extraDataMid = _midInterpreter.ParseExtra<Mid2501>(mid);
        //     Assert.AreEqual(10, extraDataMid.ProgramId);
        //     Assert.AreEqual(NodeType.ParameterSet, extraDataMid.NodeType);
        //     AssertEqualPackages(package, mid);
        // }

        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ByteArray")]
        // public void Mid2501ExtraDataByteRevision1()
        // {
        //     string package = "00360006001         2501001070010001";
        //     byte[] bytes = GetAsciiBytes(package);
        //     var mid = _midInterpreter.Parse<Mid0006>(bytes);
        //     var extraDataMid = _midInterpreter.ParseExtra<Mid2501>(mid);

        //     Assert.AreEqual(10, extraDataMid.ProgramId);
        //     Assert.AreEqual(NodeType.ParameterSet, extraDataMid.NodeType);
        //     AssertEqualPackages(bytes, mid);
        // }
    }
}
