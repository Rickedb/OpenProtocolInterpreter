using OpenProtocolInterpreter.MIDs.Communication;
using OpenProtocolInterpreter.MIDs.VIN;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class DownloadProductCommand
    {
        private readonly OpenProtocolDriver driver;

        public DownloadProductCommand(OpenProtocolDriver driver)
        {
            this.driver = driver;
        }

        public bool Execute(string vinNumber)
        {
            Console.WriteLine($"Sending product <{vinNumber}> to controller!");
            var mid = driver.sendAndWaitForResponse(new MID_0050() { VINNumber = vinNumber }.buildPackage(), new TimeSpan(0, 0, 10));

            if (mid.HeaderData.Mid == MID_0004.MID)
            {
                this.onProductRefused(mid as MID_0004);
                return false;
            }

            this.onProductAccepted(mid as MID_0005);
            return true;
        }

        private void onProductAccepted(MID_0005 mid)
        {
            Console.WriteLine("Product Accepted by controller!");
        }

        private void onProductRefused(MID_0004 mid)
        {
            Console.WriteLine($"Error thrown by controller, product rejected under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}
