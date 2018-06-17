using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
