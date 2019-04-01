using OpenProtocolInterpreter.MIDs.Communication;
using OpenProtocolInterpreter.MIDs.Job;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class SendJobCommand
    {
        private readonly OpenProtocolDriver driver;

        public SendJobCommand(OpenProtocolDriver driver)
        {
            this.driver = driver;
        }

        public bool Execute(int jobId)
        {
            Console.WriteLine($"Sending job <{jobId}> to controller!");
            var mid = driver.sendAndWaitForResponse(new MID_0038(jobId).buildPackage(), new TimeSpan(0, 0, 10));

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
            Console.WriteLine("Job Accepted by controller!");
        }

        private void onJobRefused(MID_0004 mid)
        {
            Console.WriteLine($"Job refused by controller under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}
