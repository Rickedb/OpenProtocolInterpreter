using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.MIDs.KeepAlive;
using OpenProtocolInterpreter.MIDs.Job;
using OpenProtocolInterpreter.MIDs.Job.Advanced;
using OpenProtocolInterpreter.MIDs.Tightening;
using OpenProtocolInterpreter.MIDs.Communication;
using OpenProtocolInterpreter.MIDs.Alarm;
using OpenProtocolInterpreter.MIDs.PowerMACS;
using OpenProtocolInterpreter.MIDs.MotorTuning;
using System.Diagnostics;

namespace MIDTesters
{
    [TestClass]
    public class MIDsTests
    {
        [TestMethod]
        public void TestMIDIdentifier()
        {
            TestCommunicationMessages();
            TestKeepAliveMessages();
            TestJobMessages();
            TestAdvancedJobMessages();
            TestTighteningMessages();
        }

        [TestMethod]
        public void Test()
        {
            var myTEmplate = new MIDIdentifier(new MID[]
            {
                new MID_0001(),
                new MID_0002(),
                new MID_0003(),
                new MID_0004(),
                new MID_0106(),
                new MID_0500(),
                new MID_0501(),
                new MID_0502(),
                new MID_0503(),
                new MID_0504()
            });

            long total = 0;
            string mid106 = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.7361836.102219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            for (int i = 0; i < 1000000; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var myMid106 = myTEmplate.IdentifyMid<MID_0504>(new MID_0504().BuildPackage());
                watch.Stop();
                Debug.WriteLine($"Elapsed: " + watch.ElapsedTicks);
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"Total Elapsed: " + new TimeSpan(total));
        }

        [TestMethod]
        public void TestCommunicationMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid04 = @"00260004001         001802";
            var myMid04 = identifier.IdentifyMid<MID_0004>(mid04);
            var package4 = myMid04.BuildPackage();

            if (mid04 != package4)
                throw new Exception("Failed to build mid 0004 package");

            string mid05 = @"00240005001         0018";
            var myMid05 = identifier.IdentifyMid<MID_0005>(mid05);
            var package5 = myMid05.BuildPackage();

            if (mid05 != package5)
                throw new Exception("Failed to build mid 0005 package");
        }

        [TestMethod]
        public void TestKeepAliveMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid9999 = @"00209999001         ";
            var myMid9999 = identifier.IdentifyMid<MID_9999>(mid9999);
            var package = myMid9999.BuildPackage();

            if (mid9999 != package)
                throw new Exception("Failed to build mid 9999 package");
        }

        [TestMethod]
        public void TestJobMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid34 = @"00200034001         ";
            var myMid34 = identifier.IdentifyMid<MID_0034>(mid34);
            var package34 = myMid34.BuildPackage();

            if (mid34 != package34)
                throw new Exception("Failed to build mid 34 package");

            string mid35 = @"00630035001         0101020030040008050003062001-12-01:20:12:45";
            var myMid35 = identifier.IdentifyMid<MID_0035>(mid35);
            var package35 = myMid35.BuildPackage();

            if (mid35 != package35)
                throw new Exception("Failed to build mid 35 package");

            string mid36 = @"00200036001         ";
            var myMid36 = identifier.IdentifyMid<MID_0036>(mid36);
            var package36 = myMid36.BuildPackage();

            if (mid36 != package36)
                throw new Exception("Failed to build mid 36 package");

            string mid37 = @"00200037001         ";
            var myMid37 = identifier.IdentifyMid<MID_0037>(mid37);
            var package37 = myMid37.BuildPackage();

            if (mid37 != package37)
                throw new Exception("Failed to build mid 37 package");

            string mid38 = @"00200038001         01";
            var myMid38 = identifier.IdentifyMid<MID_0038>(mid38);
            var package38 = myMid38.BuildPackage();

            if (mid38 != package38)
                throw new Exception("Failed to build mid 38 package");
        }

        [TestMethod]
        public void TestAdvancedJobMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid127 = @"00200127001         ";
            var myMid127 = identifier.IdentifyMid<MID_0127>(mid127);
            var package = myMid127.BuildPackage();

            if (mid127 != package)
                throw new Exception("Failed to build mid 127 package");
        }

        [TestMethod]
        public void TestTighteningMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            //MID 60
            string mid60 = @"00200060001         ";
            var myMid60 = identifier.IdentifyMid<MID_0060>(mid60);
            var package60 = myMid60.BuildPackage();

            if (mid60 != package60)
                throw new Exception("Failed to build mid 60 package");

            //MID 61
            string mid61 = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          " +
                           "05000600307000008000009010011112000840130014001400120015000739160000017099991800000" +
                           "1900000202001-06-02:09:54:09212001-05-29:12:34:3322123345675    ";
            var myMid61 = identifier.IdentifyMid<MID_0061>(mid61);
            var package61 = myMid61.BuildPackage();

            if (mid61 != package61)
                throw new Exception("Failed to build mid 61 package");

            //MID 62
            string mid62 = @"00200062001         ";
            var myMid62 = identifier.IdentifyMid<MID_0062>(mid62);
            var package62 = myMid62.BuildPackage();

            if (mid62 != package62)
                throw new Exception("Failed to build mid 62 package");

            //MID 63
            string mid63 = @"00200063001         ";
            var myMid63 = identifier.IdentifyMid<MID_0063>(mid63);
            var package63 = myMid63.BuildPackage();

            if (mid63 != package63)
                throw new Exception("Failed to build mid 63 package");

            //MID 64
            string mid64 = @"00300064001         0         ";
            var myMid64 = identifier.IdentifyMid<MID_0064>(mid64);
            var package64 = myMid64.BuildPackage();

            if (mid64 != package64)
                throw new Exception("Failed to build mid 64 package");

            //MID 65
            string mid65 = @"01180065001         01456789    02AIRBAG                   " +
                            "03001040002050060070080014670900046102001-04-22:14:54:34112";
            var myMid65 = identifier.IdentifyMid<MID_0065>(mid65);
            var package65 = myMid65.BuildPackage();

            if (mid65 != package65)
                throw new Exception("Failed to build mid 65 package");
        }

        [TestMethod]
        public void TestMotorTuningMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();
            long total = 0;
            for (int i = 0; i < 1000000; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var myMid500 = identifier.IdentifyMid<MID_0500>(new MID_0500().BuildPackage());
                watch.Stop();
                Debug.WriteLine($"Elapsed: " + watch.ElapsedTicks);
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"Total Elapsed: " + new TimeSpan(total));
            
        }

        [TestMethod]
        public void TestProcessingTime()
        {
            Stopwatch watch = new Stopwatch();
            long total = 0;
            string mid61 = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          " +
                           "05000600307000008000009010011112000840130014001400120015000739160000017099991800000" +
                           "1900000202001-06-02:09:54:09212001-05-29:12:34:3322123345675    ";
            //CustomMids
            watch.Start();
            var myTEmplate = new MIDIdentifier(new MID[]
            {
                new MID_0001(),
                new MID_0002(),
                new MID_0003(),
                new MID_0004(),
                new MID_0061(),
                new MID_0500(),
                new MID_0501(),
                new MID_0502(),
                new MID_0503(),
                new MID_0504()
            });
            watch.Stop();
            Debug.WriteLine("[CustomMIDs] Elapsed time to construct MIDIdentifier: " + new TimeSpan(watch.ElapsedTicks));
            
            for (int i = 0; i < 1000000; i++)
            {
                
                watch.Start();
                var myMid106 = myTEmplate.IdentifyMid<MID_0061>(mid61);
                watch.Stop();
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"[CustomMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[CustomMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));

            //All MIDs
            watch.Start();
            myTEmplate = new MIDIdentifier();
            watch.Stop();
            Debug.WriteLine("[AllMIDs] Elapsed time to construct MIDIdentifier: " + new TimeSpan(watch.ElapsedTicks));

            total = 0;
            for (int i = 0; i < 1000000; i++)
            {
                watch.Start();
                var myMid500 = myTEmplate.IdentifyMid<MID_0061>(mid61);
                watch.Stop();
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"[AllMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[AllMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));
        }
    }
}
