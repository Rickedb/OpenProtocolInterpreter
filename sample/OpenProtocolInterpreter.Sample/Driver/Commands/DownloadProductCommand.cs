using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Vin;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class DownloadProductCommand
    {
        private readonly OpenProtocolDriver _driver;

        public DownloadProductCommand(OpenProtocolDriver driver)
        {
            _driver = driver;
        }

        public bool Execute(string vinNumber)
        {
            Console.WriteLine($"Sending product <{vinNumber}> to controller!");
            var mid = _driver.SendAndWaitForResponse(new Mid0050() { VinNumber = vinNumber }.Pack(), new TimeSpan(0, 0, 10));

            if (mid.HeaderData.Mid == Mid0004.MID)
            {
                OnProductRefused(mid as Mid0004);
                return false;
            }

            OnProductAccepted(mid as Mid0005);
            return true;
        }

        private void OnProductAccepted(Mid0005 mid)
        {
            Console.WriteLine("Product Accepted by controller!");
        }

        private void OnProductRefused(Mid0004 mid)
        {
            Console.WriteLine($"Error thrown by controller, product rejected under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}