using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    [TestCategory("Vin")]
    public class TestMid0053 : DefaultMidTests<Mid0053>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0053AllRevisions()
        {
            string package = "00200053001         ";
            var mid = _midInterpreter.Parse<Mid0053>(package);

            AssertEqualPackages(package, mid);
        }
    }
}
