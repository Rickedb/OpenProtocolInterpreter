using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Result;

using OpenProtocolInterpreter;
using System;
using System.Collections.Generic;
namespace MIDTesters.Result
{
    [TestClass]
    [TestCategory("Result")]
    public class TestMid1201 : DefaultMidTests<Mid1201>
    {
        private const string Revision1Package = "01581201            00200100000001532022-11-14:09:35:1000000300100001110012000301000003010000000005010030190500000002022-08-12:13:33:2201001006040000001TORQUE";
        private const string Revision2Package = "01621201002         00200100000001532022-11-14:09:35:10000000800300100001110012000301000003010000000005010030190500000002022-08-12:13:33:2201001006040000001TORQUE";
        private const string Revision3Package = "01771201003         00200100000001532022-11-14:09:35:10000000800300100300920011120093001204009400301000003010000000005010030190500000002022-08-12:13:33:2201001006040000001TORQUE";

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid1201Revision1()
        {
            var mid = _midInterpreter.Parse<Mid1201>(Revision1Package);

            AssertParsedMid1201(mid, revision: 1);
            AssertEqualPackages(Revision1Package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision1()
        {
            byte[] bytes = GetAsciiBytes(Revision1Package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertParsedMid1201(mid, revision: 1);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid1201Revision2()
        {
            var mid = _midInterpreter.Parse<Mid1201>(Revision2Package);

            AssertParsedMid1201(mid, revision: 2);
            AssertEqualPackages(Revision2Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision2()
        {
            byte[] bytes = GetAsciiBytes(Revision2Package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertParsedMid1201(mid, revision: 2);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid1201Revision3()
        {
            var mid = _midInterpreter.Parse<Mid1201>(Revision3Package);

            AssertParsedMid1201(mid, revision: 3);
            AssertEqualPackages(Revision3Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid1201ByteRevision3()
        {
            byte[] bytes = GetAsciiBytes(Revision3Package);
            var mid = _midInterpreter.Parse<Mid1201>(bytes);

            AssertParsedMid1201(mid, revision: 3);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid1201PackRevision1()
        {
            AssertBuildAndParse(Revision1Package, BuildMid1201(1), true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid1201PackRevision2()
        {
            var mid = BuildMid1201(2);
            mid.RequestMid = 8;

            AssertBuildAndParse(Revision2Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid1201PackRevision3()
        {
            var mid = BuildMid1201(3);
            mid.RequestMid = 8;

            AssertBuildAndParse(Revision3Package, mid);
        }

        private static Mid1201 BuildMid1201(int revision)
        {
            return new Mid1201(revision)
            {
                TotalNumberOfMessages = 2,
                MessageNumber = 1,
                ResultDataIdentifier = 153,
                Time = new DateTime(2022, 11, 14, 9, 35, 10),
                ResultStatus = 0,
                OperationType = OperationType.NonSynchronizedTightening,
                ObjectDataList = BuildObjectDataList(revision),
                VariableDataFields = BuildVariableDataFields()
            };
        }

        /// <summary>
        /// The object type and the reference object id only exist from revision 3 onwards, so they are left
        /// at their default on the earlier revisions where they are not part of the message.
        /// </summary>
        private static List<ObjectData> BuildObjectDataList(int revision)
        {
            if (revision < 3)
            {
                return new List<ObjectData>()
                {
                    new ObjectData() { Id = 10, Status = false },
                    new ObjectData() { Id = 11, Status = true },
                    new ObjectData() { Id = 12, Status = false }
                };
            }

            return new List<ObjectData>()
            {
                new ObjectData() { Id = 10, Status = false, ObjectType = ObjectType.TighteningSimulation, ReferenceObjectId = 92 },
                new ObjectData() { Id = 11, Status = true, ObjectType = ObjectType.TighteningProduction, ReferenceObjectId = 93 },
                new ObjectData() { Id = 12, Status = false, ObjectType = ObjectType.JointCheck, ReferenceObjectId = 94 }
            };
        }

        private static List<VariableDataField> BuildVariableDataFields()
        {
            return new List<VariableDataField>()
            {
                new VariableDataField() { ParameterId = 1000, Length = 3, DataType = DataTypeDefinition.UnsignedInteger, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "005" },
                new VariableDataField() { ParameterId = 1003, Length = 19, DataType = DataTypeDefinition.Timestamp, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "2022-08-12:13:33:22" },
                new VariableDataField() { ParameterId = 1001, Length = 6, DataType = DataTypeDefinition.String, Unit = DataUnitType.NoUnit, StepNumber = 1, DataValue = "TORQUE" }
            };
        }

        private static void AssertParsedMid1201(Mid1201 mid, int revision)
        {
            Assert.AreEqual(2, mid.TotalNumberOfMessages);
            Assert.AreEqual(1, mid.MessageNumber);
            Assert.AreEqual(153, mid.ResultDataIdentifier);
            Assert.AreEqual(new DateTime(2022, 11, 14, 9, 35, 10), mid.Time);
            Assert.AreEqual(0, mid.ResultStatus);
            Assert.AreEqual(OperationType.NonSynchronizedTightening, mid.OperationType);

            if (revision > 1)
            {
                Assert.AreEqual(8, mid.RequestMid);
            }

            Assert.AreEqual(3, mid.NumberOfObjects);
            Assert.AreEqual(3, mid.ObjectDataList.Count);
            Assert.AreEqual(10, mid.ObjectDataList[0].Id);
            Assert.IsFalse(mid.ObjectDataList[0].Status);
            Assert.AreEqual(11, mid.ObjectDataList[1].Id);
            Assert.IsTrue(mid.ObjectDataList[1].Status);
            Assert.AreEqual(12, mid.ObjectDataList[2].Id);
            Assert.IsFalse(mid.ObjectDataList[2].Status);

            if (revision > 2)
            {
                Assert.AreEqual(ObjectType.TighteningSimulation, mid.ObjectDataList[0].ObjectType);
                Assert.AreEqual(92, mid.ObjectDataList[0].ReferenceObjectId);
                Assert.AreEqual(ObjectType.TighteningProduction, mid.ObjectDataList[1].ObjectType);
                Assert.AreEqual(93, mid.ObjectDataList[1].ReferenceObjectId);
                Assert.AreEqual(ObjectType.JointCheck, mid.ObjectDataList[2].ObjectType);
                Assert.AreEqual(94, mid.ObjectDataList[2].ReferenceObjectId);
            }

            Assert.AreEqual(3, mid.NumberOfDataFields);
            Assert.AreEqual(3, mid.VariableDataFields.Count);

            var unsignedInteger = mid.VariableDataFields[0];
            Assert.AreEqual(1000, unsignedInteger.ParameterId);
            Assert.AreEqual(3, unsignedInteger.Length);
            Assert.AreEqual(DataTypeDefinition.UnsignedInteger, unsignedInteger.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, unsignedInteger.Unit);
            Assert.AreEqual(0, unsignedInteger.StepNumber);
            Assert.AreEqual("005", unsignedInteger.DataValue);

            var timestamp = mid.VariableDataFields[1];
            Assert.AreEqual(1003, timestamp.ParameterId);
            Assert.AreEqual(19, timestamp.Length);
            Assert.AreEqual(DataTypeDefinition.Timestamp, timestamp.DataType);
            Assert.AreEqual(0, timestamp.StepNumber);
            Assert.AreEqual("2022-08-12:13:33:22", timestamp.DataValue);

            var text = mid.VariableDataFields[2];
            Assert.AreEqual(1001, text.ParameterId);
            Assert.AreEqual(6, text.Length);
            Assert.AreEqual(DataTypeDefinition.String, text.DataType);
            Assert.AreEqual(1, text.StepNumber);
            Assert.AreEqual("TORQUE", text.DataValue);
        }
    }
}
