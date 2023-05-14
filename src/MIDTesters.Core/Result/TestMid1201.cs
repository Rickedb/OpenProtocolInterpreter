using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Result;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Core.Result
{
    [TestClass]
    public class TestMid1201 : DefaultMidTests<Mid1201>
    {
        [TestMethod]
        public void Mid1201Revision1()
        {
            string package = "00691201            00200100000001532022-11-14:09:35:1000000100100000";
            var mid = _midInterpreter.Parse<Mid1201>(package);

            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid1201ByteRevision1()
        {
            string package = "00691201            00200100000001532022-11-14:09:35:1000000100100000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertEqualPackages(bytes, mid, true);
        }
    }
}
