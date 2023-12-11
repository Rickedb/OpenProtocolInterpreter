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

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid1201Revision2()
        {
            string package = "00731201002         00200100000001532022-11-14:09:35:10000000800100100000";
            var mid = _midInterpreter.Parse<Mid1201>(package);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision2()
        {
            string package = "00731201002         00200100000001532022-11-14:09:35:10000000800100100000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid1201Revision3()
        {
            string package = "00781201003         00200100000001532022-11-14:09:35:1000000080010010030092000";
            var mid = _midInterpreter.Parse<Mid1201>(package);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision3()
        {
            string package = "00781201003         00200100000001532022-11-14:09:35:1000000080010010030092000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertEqualPackages(bytes, mid);
        }
    }
}
