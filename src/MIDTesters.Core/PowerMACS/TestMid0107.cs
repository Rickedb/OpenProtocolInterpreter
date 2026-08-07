using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.PowerMACS;
using System;

using System.Collections.Generic;
namespace MIDTesters.PowerMACS
{
    [TestClass]
    [TestCategory("PowerMACS")]
    public class TestMid0107 : DefaultMidTests<Mid0107>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0107Revision1()
        {
            string pack = @"03510107001         010202020300000381270401052017-05-25:09:51:3806000107My first bolt       08Ap.320Nm Diant.P11  09310                                                  11E3211202Variable 1          I 1234567Variable 2          F 9999.9913002141Step Variable name 1I 765432101Step Variable name 2F 11.1234021501Special Value 1     S 13Got 13 digits01";
            var mid = _midInterpreter.Parse<Mid0107>(pack);

            Assert.AreEqual(2, mid.TotalNumberOfMessages);
            Assert.AreEqual(2, mid.MessageNumber);
            Assert.AreEqual(38127, mid.DataNumberSystem);
            Assert.AreEqual(1, mid.StationNumber);
            Assert.AreEqual(new DateTime(2017, 5, 25, 9, 51, 38), mid.Time);
            Assert.AreEqual(1, mid.BoltNumber);
            Assert.AreEqual("My first bolt", mid.BoltName.TrimEnd());
            Assert.AreEqual("Ap.320Nm Diant.P11", mid.ProgramName.TrimEnd());
            Assert.AreEqual(PowerMacsStatus.TermNok, mid.PowerMacsStatus);
            Assert.AreEqual("                                                  ", mid.Errors);
            Assert.AreEqual("E321", mid.CustomerErrorCode);
            Assert.AreEqual(2, mid.BoltResults.Count);
            Assert.AreEqual(2, mid.StepResults.Count);
            Assert.IsTrue(mid.AllStepDataSent);
            Assert.AreEqual(1, mid.SpecialValues.Count);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0107ByteRevision1()
        {
            string package = @"03510107001         010202020300000381270401052017-05-25:09:51:3806000107My first bolt       08Ap.320Nm Diant.P11  09310                                                  11E3211202Variable 1          I 1234567Variable 2          F 9999.9913002141Step Variable name 1I 765432101Step Variable name 2F 11.1234021501Special Value 1     S 13Got 13 digits01";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0107>(bytes);

            Assert.AreEqual(2, mid.TotalNumberOfMessages);
            Assert.AreEqual(2, mid.MessageNumber);
            Assert.AreEqual(38127, mid.DataNumberSystem);
            Assert.AreEqual(1, mid.StationNumber);
            Assert.AreEqual(new DateTime(2017, 5, 25, 9, 51, 38), mid.Time);
            Assert.AreEqual(1, mid.BoltNumber);
            Assert.AreEqual("My first bolt", mid.BoltName.TrimEnd());
            Assert.AreEqual("Ap.320Nm Diant.P11", mid.ProgramName.TrimEnd());
            Assert.AreEqual(PowerMacsStatus.TermNok, mid.PowerMacsStatus);
            Assert.AreEqual("                                                  ", mid.Errors);
            Assert.AreEqual("E321", mid.CustomerErrorCode);
            Assert.AreEqual(2, mid.BoltResults.Count);
            Assert.AreEqual(2, mid.StepResults.Count);
            Assert.IsTrue(mid.AllStepDataSent);
            Assert.AreEqual(1, mid.SpecialValues.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0107PackRevision1()
        {
            string package = "03510107001         010202020300000381270401052017-05-25:09:51:3806000107My first bolt       08Ap.320Nm Diant.P11  09310                                                  11E3211202Variable 1          I 1234567Variable 2          F 9999.9913002141Step Variable name 1I 765432101Step Variable name 2F 11.1234021501Special Value 1     S 13Got 13 digits01";

            AssertBuildAndParse(package, new Mid0107()
            {
                TotalNumberOfMessages = 2,
                MessageNumber = 2,
                DataNumberSystem = 38127L,
                StationNumber = 1,
                Time = new DateTime(2017, 5, 25, 9, 51, 38),
                BoltNumber = 1,
                BoltName = "My first bolt",
                ProgramName = "Ap.320Nm Diant.P11",
                PowerMacsStatus = PowerMacsStatus.TermNok,
                Errors = "",
                CustomerErrorCode = "E321",
                NumberOfBoltResults = 2,
                BoltResults = new List<BoltResult>()
                {
                    new BoltResult()
                    {
                        VariableName = "Variable 1",
                        Type = "I",
                        Value = 1234567
                    },
                    new BoltResult()
                    {
                        VariableName = "Variable 2",
                        Type = "F",
                        Value = 9999.99m
                    }
                },
                NumberOfStepResults = 2,
                AllStepDataSent = true,
                StepResults = new List<StepResult>()
                {
                    new StepResult()
                    {
                        VariableName = "Step Variable name 1",
                        Type = "I",
                        Value = 7654321,
                        StepNumber = 1
                    },
                    new StepResult()
                    {
                        VariableName = "Step Variable name 2",
                        Type = "F",
                        Value = 11.1234m,
                        StepNumber = 2
                    }
                },
                SpecialValues = new List<SpecialValue>()
                {
                    new SpecialValue()
                    {
                        VariableName = "Special Value 1",
                        Type = "S",
                        Length = 13,
                        Value = "Got 13 digits",
                        StepNumber = 1
                    }
                }
            });
        }
    }
}
