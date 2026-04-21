using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
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

        [Benchmark(Description = "Build MidInterpreter (custom MIDs)")]
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

        [Benchmark(Description = "Build MidInterpreter (all MIDs)")]
        public MidInterpreter BuildAllMidInterpreter() =>
            new MidInterpreter().UseAllMessages();

        [Benchmark(Description = "Parse Mid0061 (custom MIDs)")]
        public Mid0061 ParseMid61CustomInterpreter() =>
            _customMidInterpreter.Parse<Mid0061>(Mid61Raw);

        [Benchmark(Description = "Parse Mid0061 (all MIDs)", Baseline = true)]
        public Mid0061 ParseMid61AllInterpreter() =>
            _allMidInterpreter.Parse<Mid0061>(Mid61Raw);
    }
}
