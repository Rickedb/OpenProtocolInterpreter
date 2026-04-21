using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.MotorTuning;
using OpenProtocolInterpreter.Tightening;
using System;

namespace MIDTesters
{
    [MemoryDiagnoser]
    public class MIDsTests
    {
        private const string Mid61Raw =
            "02310061001         010001020103airbag7                  04KPOL3456JKLO897          " +
            "05000600307000008000009010011112000840130014001400120015000739160000017099991800000" +
            "1900000202001-06-02:09:54:09212001-05-29:12:34:3322123345675    ";

        private MidInterpreter _customMidInterpreter = null!;
        private MidInterpreter _allMidInterpreter = null!;

        [GlobalSetup]
        public void Setup()
        {
            _customMidInterpreter = new MidInterpreter()
                .UseAllMessages(new Type[]
                {
                    typeof(Mid0001),
                    typeof(Mid0002),
                    typeof(Mid0003),
                    typeof(Mid0004),
                    typeof(Mid0061),
                    typeof(Mid0500),
                    typeof(Mid0501),
                    typeof(Mid0502),
                    typeof(Mid0503),
                    typeof(Mid0504)
                });

            _allMidInterpreter = new MidInterpreter().UseAllMessages();
        }

        //[Benchmark(Description = "Build MidInterpreter (custom MIDs)")]
        public MidInterpreter BuildCustomMidInterpreter() =>
            new MidInterpreter().UseAllMessages(new Type[]
            {
                typeof(Mid0001),
                typeof(Mid0002),
                typeof(Mid0003),
                typeof(Mid0004),
                typeof(Mid0061),
                typeof(Mid0500),
                typeof(Mid0501),
                typeof(Mid0502),
                typeof(Mid0503),
                typeof(Mid0504)
            });

        //[Benchmark(Description = "Build MidInterpreter (all MIDs)")]
        public MidInterpreter BuildAllMidInterpreter() =>
            new MidInterpreter().UseAllMessages();

        //[Benchmark(Description = "Parse Mid0061 (custom MIDs)")]
        public Mid0061 ParseMid61CustomInterpreter() =>
            _customMidInterpreter.Parse<Mid0061>(Mid61Raw);

        //[Benchmark(Description = "Parse Mid0061 (all MIDs)", Baseline = true)]
        public Mid0061 ParseMid61AllInterpreter() =>
            _allMidInterpreter.Parse<Mid0061>(Mid61Raw);

        [Benchmark(Description = "Mid performance")]
        public Mid MidPerformance()
        {
            var value = "02240002007         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A171";
            var mid = _allMidInterpreter.Parse<Mid0002>(value);
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.IsFalse(mid.SequenceNumberSupport);
            Assert.IsTrue(mid.LinkingHandlingSupport);
            Assert.AreEqual(4294967295L, mid.StationCellId);
            Assert.AreEqual("Station Or Cell Name", mid.StationCellName.TrimEnd());
            Assert.AreEqual("A", mid.ClientId);
            Assert.IsTrue(mid.OptionalKeepAlive);
            return mid;
        }
    }
}
