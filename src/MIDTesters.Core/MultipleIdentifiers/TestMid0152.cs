using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0152 : DefaultMidTests<Mid0152>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0152Revision1()
        {
            string package = "01480152001         0110101Result part 1            0220003Result part 2            0330104Result part 3            0440105Result part 4            ";
            var mid = _midInterpreter.Parse<Mid0152>(package);

            Assert.AreEqual(1, mid.FirstIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.FirstIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Accepted, mid.FirstIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 1", mid.FirstIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(2, mid.SecondIdentifierStatus.IdentifierTypeNumber);
            Assert.IsFalse(mid.SecondIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Reset, mid.SecondIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 2", mid.SecondIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(3, mid.ThirdIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.ThirdIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Next, mid.ThirdIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 3", mid.ThirdIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(4, mid.FourthIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.FourthIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Initial, mid.FourthIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 4", mid.FourthIdentifierStatus.ResultPart.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0152ByteRevision1()
        {
            string package = "01480152001         0110101Result part 1            0220003Result part 2            0330104Result part 3            0440105Result part 4            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0152>(bytes);

            Assert.AreEqual(1, mid.FirstIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.FirstIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Accepted, mid.FirstIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 1", mid.FirstIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(2, mid.SecondIdentifierStatus.IdentifierTypeNumber);
            Assert.IsFalse(mid.SecondIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Reset, mid.SecondIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 2", mid.SecondIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(3, mid.ThirdIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.ThirdIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Next, mid.ThirdIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 3", mid.ThirdIdentifierStatus.ResultPart.TrimEnd());
            Assert.AreEqual(4, mid.FourthIdentifierStatus.IdentifierTypeNumber);
            Assert.IsTrue(mid.FourthIdentifierStatus.IncludedInWorkOrder);
            Assert.AreEqual(StatusInWorkOrder.Initial, mid.FourthIdentifierStatus.StatusInWorkOrder);
            Assert.AreEqual("Result part 4", mid.FourthIdentifierStatus.ResultPart.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }
    }
}
