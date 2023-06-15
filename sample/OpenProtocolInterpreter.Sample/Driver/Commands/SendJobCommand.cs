using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Job;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class SendJobCommand
    {
        private readonly OpenProtocolDriver _driver;

        public SendJobCommand(OpenProtocolDriver driver)
        {
            _driver = driver;
        }

        public bool Execute(int jobId)
        {
            Console.WriteLine($"Sending job <{jobId}> to controller!");
            var mid = _driver.SendAndWaitForResponse(new Mid0038(jobId).Pack(), new TimeSpan(0, 0, 10));

            if (mid.Header.Mid == Mid0004.MID)
            {
                OnJobRefused(mid as Mid0004);
                return false;
            }

            OnJobAccepted(mid as Mid0005);
            return true;
        }

        private void OnJobAccepted(Mid0005 mid)
        {
            Console.WriteLine($"Job Accepted by controller!");
        }

        private void OnJobRefused(Mid0004 mid)
        {
            Console.WriteLine($"Job refused by controller under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}