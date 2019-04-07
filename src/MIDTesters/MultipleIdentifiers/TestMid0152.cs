using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;
using System.Linq;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0152 : MidTester
    {
        [TestMethod]
        public void Mid0152Revision1()
        {
            string package = "01480152001         0110101Result part 1            0220003Result part 2            0330104Result part 3            0440105Result part 4            ";
            var mid = _midInterpreter.Parse<Mid0152>(package);

            Assert.AreEqual(typeof(Mid0152), mid.GetType());
            Assert.IsNotNull(mid.FirstIdentifierStatus);
            Assert.IsNotNull(mid.SecondIdentifierStatus);
            Assert.IsNotNull(mid.ThirdIdentifierStatus);
            Assert.IsNotNull(mid.FourthIdentifierStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0152ByteRevision1()
        {
            string package = "01480152001         0110101Result part 1            0220003Result part 2            0330104Result part 3            0440105Result part 4            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0152>(bytes);

            Assert.AreEqual(typeof(Mid0152), mid.GetType());
            Assert.IsNotNull(mid.FirstIdentifierStatus);
            Assert.IsNotNull(mid.SecondIdentifierStatus);
            Assert.IsNotNull(mid.ThirdIdentifierStatus);
            Assert.IsNotNull(mid.FourthIdentifierStatus);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
