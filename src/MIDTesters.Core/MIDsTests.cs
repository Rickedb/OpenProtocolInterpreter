using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.MotorTuning;
using OpenProtocolInterpreter.Tightening;
using System;
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
            var myTEmplate = new MidInterpreter()
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

            Debug.WriteLine($"[AllMIDs] Total Elapsed: " + new TimeSpan(total));
            Debug.WriteLine($"[AllMIDs] Average Elapsed Time: " + new TimeSpan(total / 1000000));
        }
    }
}
