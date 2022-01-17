using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Core
{
    [TestClass]
    public class TestMidExtensions
    {
        public TestMidExtensions()
        {
            
        }

        [TestMethod]
        public void TestPackWithNul()
        {
            var package = new Mid0001(true).PackWithNul();
            Assert.IsNotNull(package);
            Assert.AreEqual('\0', package[package.Length - 1]);
        }

        [TestMethod]
        public void TestPackBytesWithNul()
        {
            var bytes = new Mid0001(true).PackBytesWithNul();
            Assert.IsNotNull(bytes);
            Assert.AreEqual(0x00, bytes[bytes.Length - 1]);
        }
    }
}
