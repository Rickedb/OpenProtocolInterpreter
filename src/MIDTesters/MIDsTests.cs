using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.PowerMACS;
using OpenProtocolInterpreter.MotorTuning;
using System.Diagnostics;

namespace MIDTesters
{
    [TestClass]
    public class MIDsTests
    {
        //[TestMethod]
        public void Test()
        {
            //var myTEmplate = new MidInterpreter(new Mid[]
            //{
            //    new MID_0001(),
            //    new MID_0002(),
            //    new MID_0003(),
            //    new MID_0004(),
            //    new MID_0106(),
            //    new MID_0500(),
            //    new MID_0501(),
            //    new MID_0502(),
            //    new MID_0503(),
            //    new MID_0504()
            //});

            //long total = 0;
            //string mid106 = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.7361836.102219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            //for (int i = 0; i < 1000000; i++)
            //{
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
            //    var myMid106 = myTEmplate.Parse<MID_0504>(new MID_0504().Pack());
            //    watch.Stop();
            //    Debug.WriteLine($"Elapsed: " + watch.ElapsedTicks);
            //    total += watch.ElapsedTicks;
            //}
            //Debug.WriteLine($"Total Elapsed: " + new TimeSpan(total));
        }

        //[TestMethod]
        public void TestMotorTuningMessages()
        {
            //MidInterpreter identifier = new MidInterpreter();
            //long total = 0;
            //for (int i = 0; i < 1000000; i++)
            //{
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
            //    var myMid500 = identifier.Parse<MID_0500>(new MID_0500().Pack());
            //    watch.Stop();
            //    Debug.WriteLine($"Elapsed: " + watch.ElapsedTicks);
            //    total += watch.ElapsedTicks;
            //}
            //Debug.WriteLine($"Total Elapsed: " + new TimeSpan(total));
            
        }

        //[TestMethod]
        public void TestProcessingTime()
        {
            Stopwatch watch = new Stopwatch();
            long total = 0;
            string mid61 = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          " +
                           "05000600307000008000009010011112000840130014001400120015000739160000017099991800000" +
                           "1900000202001-06-02:09:54:09212001-05-29:12:34:3322123345675    ";
            //CustomMids
            watch.Start();
            var myTEmplate = new MidInterpreter(new Mid[]
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
            Debug.WriteLine("[CustomMIDs] Elapsed time to construct MidInterpreter: " + new TimeSpan(watch.ElapsedTicks));
            
            for (int i = 0; i < 1000000; i++)
            {
                
                watch.Start();
                var myMid106 = myTEmplate.Parse<MID_0061>(mid61);
                watch.Stop();
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"[CustomMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[CustomMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));

            //All MIDs
            watch.Start();
            myTEmplate = new MidInterpreter();
            watch.Stop();
            Debug.WriteLine("[AllMIDs] Elapsed time to construct MidInterpreter: " + new TimeSpan(watch.ElapsedTicks));

            total = 0;
            for (int i = 0; i < 1000000; i++)
            {
                watch.Start();
                var myMid500 = myTEmplate.Parse<MID_0061>(mid61);
                watch.Stop();
                total += watch.ElapsedTicks;
            }
            Debug.WriteLine($"[AllMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[AllMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));
        }
    }
}
