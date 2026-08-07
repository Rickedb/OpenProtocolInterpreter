using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Tool;
using System.Collections.Generic;

using OpenProtocolInterpreter;
namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0704 : DefaultMidTests<Mid0704>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0704Revision1()
        {
            string package = "00700704001         00201200012040000000QST50-150CTT012150010200000003";
            var mid = _midInterpreter.Parse<Mid0704>(package);

            Assert.AreEqual(2, mid.NumberOfDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0704ByteRevision1()
        {
            string package = "00700704001         00201200012040000000QST50-150CTT012150010200000003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0704>(bytes);

            Assert.AreEqual(2, mid.NumberOfDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0704ExtraDataRequestRevision1()
        {
            string package = "00480006001         0704001190001002001213001215";
            var mid = _midInterpreter.Parse<Mid0006>(package);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataRequest>(mid);

            Assert.AreEqual(Mid0006.MID, mid.Header.Mid);
            Assert.AreEqual(Mid0704.MID, mid.RequestedMid);
            Assert.AreEqual(1, mid.WantedRevision);
            Assert.AreEqual(19, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            Assert.AreEqual(2, extraData.TotalRequestedPIDs);
            Assert.AreEqual(2, extraData.RequestedPIDs.Count);
            Assert.AreEqual(1213, extraData.RequestedPIDs[0]);
            Assert.AreEqual(1215, extraData.RequestedPIDs[1]);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0704ExtraDataRequestByteRevision1()
        {
            string package = "00480006001         0704001190001002001213001215";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0006>(bytes);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataRequest>(mid);

            Assert.AreEqual(Mid0704.MID, mid.RequestedMid);
            Assert.AreEqual(19, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            Assert.AreEqual(2, extraData.TotalRequestedPIDs);
            Assert.AreEqual(2, extraData.RequestedPIDs.Count);
            Assert.AreEqual(1213, extraData.RequestedPIDs[0]);
            Assert.AreEqual(1215, extraData.RequestedPIDs[1]);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0704ExtraDataRequestPackRevision1()
        {
            string package = "00480006001         0704001190001002001213001215";
            var mid = new Mid0006();

            mid.SetExtraData(new Mid0704ExtraDataRequest(1)
            {
                ToolNumber = 1,
                RequestedPIDs = new List<int>() { 1213, 1215 }
            });

            Assert.AreEqual(Mid0704.MID, mid.RequestedMid);
            Assert.AreEqual(19, mid.ExtraDataLength);
            Assert.AreEqual("0001002001213001215", mid.ExtraData);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0704ExtraDataSubscriptionRevision1()
        {
            string package = "00540008001         0704001250001002001213005001215000";
            var mid = _midInterpreter.Parse<Mid0008>(package);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataSubscription>(mid);

            Assert.AreEqual(Mid0008.MID, mid.Header.Mid);
            Assert.AreEqual(Mid0704.MID, mid.SubscriptionMid);
            Assert.AreEqual(1, mid.WantedRevision);
            Assert.AreEqual(25, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            Assert.AreEqual(2, extraData.NumberOfPIDs);
            Assert.AreEqual(2, extraData.PIDRestrictions.Count);
            Assert.AreEqual(1213, extraData.PIDRestrictions[0].PID);
            Assert.AreEqual(5, extraData.PIDRestrictions[0].Restriction);
            Assert.AreEqual(1215, extraData.PIDRestrictions[1].PID);
            Assert.AreEqual(0, extraData.PIDRestrictions[1].Restriction);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0704ExtraDataSubscriptionByteRevision1()
        {
            string package = "00540008001         0704001250001002001213005001215000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0008>(bytes);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataSubscription>(mid);

            Assert.AreEqual(Mid0704.MID, mid.SubscriptionMid);
            Assert.AreEqual(25, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            Assert.AreEqual(2, extraData.NumberOfPIDs);
            Assert.AreEqual(2, extraData.PIDRestrictions.Count);
            Assert.AreEqual(1213, extraData.PIDRestrictions[0].PID);
            Assert.AreEqual(5, extraData.PIDRestrictions[0].Restriction);
            Assert.AreEqual(1215, extraData.PIDRestrictions[1].PID);
            Assert.AreEqual(0, extraData.PIDRestrictions[1].Restriction);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0704ExtraDataSubscriptionPackRevision1()
        {
            string package = "00540008001         0704001250001002001213005001215000";
            var mid = new Mid0008();

            mid.SetExtraData(new Mid0704ExtraDataSubscription(1)
            {
                ToolNumber = 1,
                PIDRestrictions = new List<PIDRestriction>()
                {
                    new PIDRestriction(1213, 5),
                    new PIDRestriction(1215, 0)
                }
            });

            Assert.AreEqual(Mid0704.MID, mid.SubscriptionMid);
            Assert.AreEqual(25, mid.ExtraDataLength);
            Assert.AreEqual("0001002001213005001215000", mid.ExtraData);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0704ExtraDataUnsubscriptionRevision1()
        {
            string package = "00330009001         0704001040001";
            var mid = _midInterpreter.Parse<Mid0009>(package);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataUnsubscription>(mid);

            Assert.AreEqual(Mid0009.MID, mid.Header.Mid);
            Assert.AreEqual(Mid0704.MID, mid.UnsubscriptionMid);
            Assert.AreEqual(1, mid.ExtraDataRevision);
            Assert.AreEqual(4, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0704ExtraDataUnsubscriptionByteRevision1()
        {
            string package = "00330009001         0704001040001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0009>(bytes);

            var extraData = _midInterpreter.ParseExtraData<Mid0704ExtraDataUnsubscription>(mid);

            Assert.AreEqual(Mid0704.MID, mid.UnsubscriptionMid);
            Assert.AreEqual(4, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.ToolNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0704ExtraDataUnsubscriptionPackRevision1()
        {
            string package = "00330009001         0704001040001";
            var mid = new Mid0009();

            mid.SetExtraData(new Mid0704ExtraDataUnsubscription(1)
            {
                ToolNumber = 1
            });

            Assert.AreEqual(Mid0704.MID, mid.UnsubscriptionMid);
            Assert.AreEqual(4, mid.ExtraDataLength);
            Assert.AreEqual("0001", mid.ExtraData);
            AssertEqualPackages(package, mid);
        }


        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0704PackRevision1()
        {
            string package = "00700704001         00201200012040000000QST50-150CTT012150010200000003";

            AssertBuildAndParse(package, new Mid0704()
            {
                NumberOfDataFields = 2,
                VariableDataFields = new List<VariableDataField>()
                {
                    new VariableDataField()
                    {
                        ParameterId = 1200,
                        Length = 12,
                        DataType = DataTypeDefinition.String,
                        Unit = DataUnitType.NoUnit,
                        StepNumber = 0,
                        DataValue = "QST50-150CTT"
                    },
                    new VariableDataField()
                    {
                        ParameterId = 1215,
                        Length = 1,
                        DataType = DataTypeDefinition.Integer,
                        Unit = DataUnitType.NoUnit,
                        StepNumber = 0,
                        DataValue = "3"
                    }
                }
            });
        }
    }
}
