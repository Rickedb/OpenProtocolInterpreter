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
    //[TestClass]
    public class MIDsTests
    {
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
                new Mid0001(),
                new Mid0002(),
                new Mid0003(),
                new Mid0004(),
                new Mid0061(),
                new Mid0500(),
                new Mid0501(),
                new Mid0502(),
                new Mid0503(),
                new Mid0504()
            });
            watch.Stop();
            Debug.WriteLine("[CustomMIDs] Elapsed time to construct MidInterpreter: " + new TimeSpan(watch.ElapsedTicks));
            
            for (int i = 0; i < 1000000; i++)
            {
                
                watch.Start();
                var myMid106 = myTEmplate.Parse<Mid0061>(mid61);
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
                var myMid500 = myTEmplate.Parse<Mid0061>(mid61);
                watch.Stop();
                total += watch.ElapsedTicks;
            }

            var myCustomInterpreter = new MidInterpreter(new Mid[]
                        {
                            new Mid0001(),
                            new Mid0002(),
                            new Mid0003(),
                            new Mid0004(),
                            new Mid0106()
                        });
            //Will work:
            Mid0004 myMid04 = myCustomInterpreter.Parse<Mid0004>(package);
            //Won't work:
            Mid0030 myMid30 = myCustomInterpreter.Parse<Mid0030>(package);

            Debug.WriteLine($"[AllMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[AllMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));
        }
    }
}
