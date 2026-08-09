using System.Text;

namespace OpenProtocolInterpreter.Benchmarks
{
    /// <summary>
    /// Open Protocol packages used across the benchmarks, taken from the test suite so every benchmark
    /// measures a package that is known to parse.
    /// <para>
    ///     A mid travels in a single direction: mids marked with <see cref="IController"/> are sent by the
    ///     controller and consumed by an integrator, mids marked with <see cref="IIntegrator"/> travel the
    ///     other way. That is what <see cref="InterpreterMode"/> filters on, so the packages are grouped by
    ///     direction here.
    /// </para>
    /// </summary>
    internal static class Packages
    {
        #region Controller originated (parsed by an integrator)

        public const string Mid0002Rev3 = "01250002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";
        public const string Mid0015Rev2 = "01410015002         0100202Airbag parameter         032017-06-02:09:54:0904205040600510107010009080050050900001109999911003601200123413001006";
        public const string Mid0035Rev3 = "00790035003         010001020030040008050003062001-12-01:20:12:4507120080100912";
        public const string Mid0061Rev1 = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";
        public const string Mid0061Rev11 = "06770061011         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124540015005500000000425600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000750001207600001";
        public const string Mid0071Rev3 = "01090071003         01E1021021031042017-12-01:20:12:4505106Alarm Text                                        ";
        public const string Mid0101Rev1 = "02100101001         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000";

        #endregion

        #region Integrator originated (parsed by a controller)

        /// <summary>Communication start, revision 7. 23 bytes.</summary>
        public const string Mid0001Rev7 = "00230001007         011";

        /// <summary>Communication stop, revision 1. 20 bytes, header only.</summary>
        public const string Mid0003Rev1 = "00200003001         ";

        /// <summary>Vehicle id number download request. 35 bytes.</summary>
        public const string Mid0050Rev1 = "00350050001         VehicleIdNumber";

        /// <summary>Last tightening result data subscribe, all revisions. 20 bytes, header only.</summary>
        public const string Mid0060Rev998 = "00200060998         ";

        /// <summary>Old tightening result upload request, revision 1. 30 bytes.</summary>
        public const string Mid0064Rev1 = "00300064001         0123456789";

        #endregion

        public static readonly string[] ControllerOriginated =
        [
            Mid0002Rev3,
            Mid0035Rev3,
            Mid0061Rev1,
            Mid0071Rev3
        ];

        public static readonly string[] IntegratorOriginated =
        [
            Mid0001Rev7,
            Mid0003Rev1,
            Mid0060Rev998,
            Mid0064Rev1
        ];

        public static readonly string[] BothDirections =
        [
            Mid0001Rev7,
            Mid0002Rev3,
            Mid0060Rev998,
            Mid0061Rev1
        ];

        public static string[] IncomingFor(InterpreterMode mode)
        {
            return mode switch
            {
                InterpreterMode.Controller => IntegratorOriginated,
                InterpreterMode.Integrator => ControllerOriginated,
                _ => BothDirections
            };
        }

        /// <summary>
        /// Returns the single package used as the representative message of the given <paramref name="mode"/>:
        /// the tightening result for anyone reading a controller, the subscription that asks for it otherwise.
        /// </summary>
        public static string RepresentativeFor(InterpreterMode mode)
        {
            return mode == InterpreterMode.Controller ? Mid0060Rev998 : Mid0061Rev1;
        }

        public static byte[] ToBytes(string package) => Encoding.ASCII.GetBytes(package);

        public static byte[][] ToBytes(string[] packages)
        {
            var bytes = new byte[packages.Length][];
            for (int i = 0; i < packages.Length; i++)
                bytes[i] = ToBytes(packages[i]);

            return bytes;
        }
    }
}
