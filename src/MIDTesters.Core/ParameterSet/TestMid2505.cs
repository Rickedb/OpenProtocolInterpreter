using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.Core.ParameterSet
{
    [TestClass]
    public class TestMid2505 : DefaultMidTests<Mid2505>
    {
        [TestMethod]
        public void Mid2505Revision1()
        {
            string package = "00822505001         01000201000003010000000005010030190500000002022-08-12:13:33:22";
            var mid = _midInterpreter.Parse<Mid2505>(package);

            Assert.AreEqual(10, mid.ParameterSetId);
            Assert.AreEqual(2, mid.NumberOfParameterDataFields);
            Assert.IsNotNull(mid.VariableDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid2505ByteRevision1()
        {
            string package = "00462505001         01000101000003010000000005";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid2505>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
