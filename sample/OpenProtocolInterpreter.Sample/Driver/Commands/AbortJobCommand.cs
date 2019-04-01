using OpenProtocolInterpreter.MIDs.Communication;
using OpenProtocolInterpreter.MIDs.Job.Advanced;
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
            var mid = driver.sendAndWaitForResponse(new MID_0127().buildPackage(), new TimeSpan(0, 0, 10));

            if (mid.HeaderData.Mid == MID_0004.MID)
            {
                this.onJobRefused(mid as MID_0004);
                return false;
            }

            this.onJobAccepted(mid as MID_0005);
            return true;
        }

        private void onJobAccepted(MID_0005 mid)
        {
            Console.WriteLine("Job Abort Accepted by controller!");
        }

        private void onJobRefused(MID_0004 mid)
        {
            Console.WriteLine($"Job Abort refused by controller under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}
