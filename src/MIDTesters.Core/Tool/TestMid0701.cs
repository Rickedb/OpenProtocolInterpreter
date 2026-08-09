using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

using System.Collections.Generic;
namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0701 : DefaultMidTests<Mid0701>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0701Revision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            var mid = _midInterpreter.Parse<Mid0701>(package);

            Assert.AreEqual(2, mid.Tools.Count);
            Assert.AreEqual(2, mid.TotalTools);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0701ByteRevision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0701>(bytes);

            Assert.AreEqual(2, mid.Tools.Count);
            Assert.AreEqual(2, mid.TotalTools);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0701PackRevision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";

            AssertBuildAndParse(package, new Mid0701()
            {
                TotalTools = 2,
                Tools = new List<ToolData>()
                {
                    new ToolData()
                    {
                        Number = 1,
                        SerialNumber = "Tool 1 Serial number",
                        ModelName = "Tool 1 Model Name",
                        ModelArticleNumber = "Tool 1 Model Article Number"
                    },
                    new ToolData()
                    {
                        Number = 2,
                        SerialNumber = "Tool 2 Serial number",
                        ModelName = "Tool 2 Model Name",
                        ModelArticleNumber = "Tool 2 Model Article Number"
                    }
                }
            });
        }
    }
}
