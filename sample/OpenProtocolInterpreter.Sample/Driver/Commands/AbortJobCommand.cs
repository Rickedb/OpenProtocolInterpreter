using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Job.Advanced;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class AbortJobCommand
    {
        private readonly OpenProtocolDriver driver;

        public AbortJobCommand(OpenProtocolDriver driver)
        {
            this.driver = driver;
        }

        public bool Execute()
        {
            Console.WriteLine($"Sending abort job to controller!");
            var mid = driver.SendAndWaitForResponse(new Mid0127().Pack(), new TimeSpan(0, 0, 10));

            if (mid.HeaderData.Mid == Mid0004.MID)
            {
                this.onJobRefused(mid as Mid0004);
                return false;
            }

            this.onJobAccepted(mid as Mid0005);
            return true;
        }

        private void onJobAccepted(Mid0005 mid)
        {
            Console.WriteLine("Job Abort Accepted by controller!");
        }

        private void onJobRefused(Mid0004 mid)
        {
            Console.WriteLine($"Job Abort refused by controller under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}