using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;
using System.Linq;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0701 : MidTester
    {
        [TestMethod]
        public void Mid0701Revision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            var mid = _midInterpreter.Parse<Mid0701>(package);

            Assert.AreEqual(typeof(Mid0701), mid.GetType());
            Assert.IsNotNull(mid.Tools);
            Assert.AreNotEqual(0, mid.TotalTools);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0701ByteRevision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0701>(bytes);

            Assert.AreEqual(typeof(Mid0701), mid.GetType());
            Assert.IsNotNull(mid.Tools);
            Assert.AreNotEqual(0, mid.TotalTools);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
