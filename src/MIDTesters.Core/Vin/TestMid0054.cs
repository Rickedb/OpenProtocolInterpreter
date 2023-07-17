using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    [TestCategory("Vin")]
    public class TestMid0054 : DefaultMidTests<Mid0054>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0054AllRevisions()
        {
            string package = "00200054            ";
            var mid = _midInterpreter.Parse<Mid0054>(package);

            AssertEqualPackages(package, mid, true);
        }
    }
}
