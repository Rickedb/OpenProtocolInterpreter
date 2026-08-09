using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Tightening;
using System;
using System.Collections.Generic;

using OpenProtocolInterpreter;
namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0067 : DefaultMidTests<Mid0067>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0067Revision1()
        {
            string package = "00820067001         0200000000012018-04-25:10:23:45100000000022018-04-25:10:24:010";
            var mid = _midInterpreter.Parse<Mid0067>(package);

            Assert.AreEqual(typeof(Mid0067), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfResults);
            Assert.AreEqual(2, mid.Results.Count);

            Assert.AreEqual(1, mid.Results[0].Index);
            Assert.AreEqual(new DateTime(2018, 4, 25, 10, 23, 45), mid.Results[0].StartTime);
            Assert.AreEqual(1, mid.Results[0].Status);

            Assert.AreEqual(2, mid.Results[1].Index);
            Assert.AreEqual(new DateTime(2018, 4, 25, 10, 24, 1), mid.Results[1].StartTime);
            Assert.AreEqual(0, mid.Results[1].Status);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0067ByteRevision1()
        {
            string package = "00820067001         0200000000012018-04-25:10:23:45100000000022018-04-25:10:24:010";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0067>(bytes);

            Assert.AreEqual(typeof(Mid0067), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfResults);
            Assert.AreEqual(2, mid.Results.Count);
            Assert.AreEqual(1, mid.Results[0].Index);
            Assert.AreEqual(2, mid.Results[1].Index);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0067EmptyListRevision1()
        {
            string package = "00220067001         00";
            var mid = _midInterpreter.Parse<Mid0067>(package);

            Assert.AreEqual(0, mid.NumberOfResults);
            Assert.AreEqual(0, mid.Results.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0067PackRevision1()
        {
            string package = "00820067001         0200000000012018-04-25:10:23:45100000000022018-04-25:10:24:010";

            AssertBuildAndParse(package, new Mid0067()
            {
                Results = new List<ResultData>()
                {
                    new ResultData()
                    {
                        Index = 1,
                        StartTime = new DateTime(2018, 4, 25, 10, 23, 45),
                        Status = 1
                    },
                    new ResultData()
                    {
                        Index = 2,
                        StartTime = new DateTime(2018, 4, 25, 10, 24, 1),
                        Status = 0
                    }
                }
            });
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0067PackEnforcesNumberOfResultsRevision1()
        {
            string package = "00520067001         0100000000012018-04-25:10:23:451";
            var mid = new Mid0067()
            {
                NumberOfResults = 99, //Overwritten by the actual list size while packing
                Results = new List<ResultData>()
                {
                    new ResultData()
                    {
                        Index = 1,
                        StartTime = new DateTime(2018, 4, 25, 10, 23, 45),
                        Status = 1
                    }
                }
            };

            Assert.AreEqual(package, mid.Pack());
            Assert.AreEqual(1, mid.NumberOfResults);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0067ExtraDataRequestRevision1()
        {
            string package = "00420006001         0067001130000000001010";
            var mid = _midInterpreter.Parse<Mid0006>(package);

            var extraData = _midInterpreter.ParseExtraData<Mid0067ExtraData>(mid);

            Assert.AreEqual(Mid0006.MID, mid.Header.Mid);
            Assert.AreEqual(Mid0067.MID, mid.RequestedMid);
            Assert.AreEqual(1, mid.WantedRevision);
            Assert.AreEqual(13, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.StartIndex);
            Assert.AreEqual(10, extraData.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0067ExtraDataRequestByteRevision1()
        {
            string package = "00420006001         0067001130000000001010";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0006>(bytes);

            var extraData = _midInterpreter.ParseExtraData<Mid0067ExtraData>(mid);

            Assert.AreEqual(Mid0067.MID, mid.RequestedMid);
            Assert.AreEqual(13, mid.ExtraDataLength);
            Assert.AreEqual(1, extraData.StartIndex);
            Assert.AreEqual(10, extraData.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0067ExtraDataRequestPackRevision1()
        {
            string package = "00420006001         0067001130000000001010";
            var mid = new Mid0006();

            mid.SetExtraData(new Mid0067ExtraData()
            {
                StartIndex = 1,
                Count = 10
            });

            Assert.AreEqual(Mid0067.MID, mid.RequestedMid);
            Assert.AreEqual(13, mid.ExtraDataLength);
            Assert.AreEqual("0000000001010", mid.ExtraData);
            AssertEqualPackages(package, mid);
        }
    }
}
