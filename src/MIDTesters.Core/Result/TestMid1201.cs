using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Result;

namespace MIDTesters.Core.Result
{
    [TestClass]
    [TestCategory("Result")]
    public class TestMid1201 : DefaultMidTests<Mid1201>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid1201Revision1()
        {
            string package = "00691201            00200100000001532022-11-14:09:35:1000000100100000";
            var mid = _midInterpreter.Parse<Mid1201>(package);

            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision1()
        {
            string package = "00691201            00200100000001532022-11-14:09:35:1000000100100000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertEqualPackages(bytes, mid, true);
        }
    }
}
