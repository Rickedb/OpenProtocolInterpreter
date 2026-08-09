using BenchmarkDotNet.Attributes;

namespace OpenProtocolInterpreter.Benchmarks
{
    public class InterpreterModeBenchmarks
    {
        private MidInterpreter _interpreter;
        private string _representative;
        private string[] _incoming;
        private byte[][] _incomingBytes;

        [Params(InterpreterMode.Both, InterpreterMode.Controller, InterpreterMode.Integrator)]
        public InterpreterMode Mode { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _representative = Packages.RepresentativeFor(Mode);
            _incoming = Packages.IncomingFor(Mode);
            _incomingBytes = Packages.ToBytes(_incoming);

            // Fail here rather than reporting a number for a mode that was silently rejecting its packages.
            _interpreter = new MidInterpreter().UseAllMessages(Mode);
            _interpreter.Parse(_representative);
            foreach (var package in _incoming)
                _interpreter.Parse(package);
        }

        [Benchmark(Description = "Register all messages")]
        public MidInterpreter Register() => new MidInterpreter().UseAllMessages(Mode);

        [Benchmark(Description = "Cold start (register + first parse)")]
        public Mid ColdStart() => new MidInterpreter().UseAllMessages(Mode).Parse(_representative);

        [Benchmark(Description = "Parse (warm)")]
        public Mid Parse() => _interpreter.Parse(_representative);

        [Benchmark(Description = "Parse session (warm, 4 packages)")]
        public Mid ParseSession()
        {
            Mid last = null;
            for (int i = 0; i < _incoming.Length; i++)
                last = _interpreter.Parse(_incoming[i]);

            return last;
        }

        [Benchmark(Description = "Parse session from bytes (warm, 4 packages)")]
        public Mid ParseSessionBytes()
        {
            Mid last = null;
            for (int i = 0; i < _incomingBytes.Length; i++)
                last = _interpreter.Parse(_incomingBytes[i]);

            return last;
        }
    }
}
