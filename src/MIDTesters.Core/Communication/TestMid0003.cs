using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0003 : DefaultMidTests<Mid0003>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0003Revision1()
        {
            string pack = @"00200003001         ";
            var mid = _midInterpreter.Parse<Mid0003>(pack);

            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0003ByteRevision1()
        {
            string pack = @"00200003001         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0003>(bytes);

            AssertEqualPackages(bytes, mid);
        }
    }
}
