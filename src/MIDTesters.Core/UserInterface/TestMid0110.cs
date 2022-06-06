using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0110 : DefaultMidTests<Mid0110>
    {
        [TestMethod]
        public void Mid0110Revision1()
        {
            string package = "00240110001         TEST";
            var mid = _midInterpreter.Parse<Mid0110>(package);

            Assert.IsNotNull(mid.UserText);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0110ByteRevision1()
        {
            string package = "00240110001         TEST";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0110>(bytes);

            Assert.IsNotNull(mid.UserText);
            AssertEqualPackages(bytes, mid);
        }
    }
}
