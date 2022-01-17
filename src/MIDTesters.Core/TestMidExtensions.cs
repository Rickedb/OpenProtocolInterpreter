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
        public void TestGetRevisionByFields()
        {
            var dictionary = new Mid0001(true).GetRevisionByFields();

            Assert.IsNotNull(dictionary);
            Assert.IsTrue(dictionary.Count > 0);

            var field = dictionary[7][0];
            Assert.AreEqual("1", field.Value);
            Assert.AreEqual((int)Mid0001.DataFields.USE_KEEPALIVE, field.Field);
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
