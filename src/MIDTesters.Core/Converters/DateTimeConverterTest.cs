using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class DateTimeConverterTest
    {
        [TestMethod]
        [TestCategory("DateTime")]
        public void DateTimeToString()
        {
            var date = new DateTime(2023, 01, 09, 13, 40, 55, 20);
            Assert.AreEqual("2023-01-09:13:40:55", OpenProtocolConvert.ToString(date));
        }

        [TestMethod]
        [TestCategory("DateTime")]
        public void DateTimeToPaddedString()
        {
            var date = new DateTime(2022, 05, 03, 3, 10, 25, 20);
            Assert.AreEqual("2022-05-03:03:10:25", OpenProtocolConvert.ToString(date));
        }

        [TestMethod]
        [TestCategory("DateTime")]
        public void StringToDateTime()
        {
            var date = "2021-02-12:23:15:05";
            var parsedDate = OpenProtocolConvert.ToDateTime(date);
            Assert.AreEqual(parsedDate.Year, 2021);
            Assert.AreEqual(parsedDate.Month, 2);
            Assert.AreEqual(parsedDate.Day, 12);
            Assert.AreEqual(parsedDate.Hour, 23);
            Assert.AreEqual(parsedDate.Minute, 15);
            Assert.AreEqual(parsedDate.Second, 5);
        }

        [TestMethod]
        [TestCategory("DateTime")]
        public void ConcurrencyTest()
        {
            var iterations = 10000;
            var done = new CountdownEvent(iterations);
            var result = Parallel.For(0, iterations, x =>
            {
                DateTimeToString();
                DateTimeToPaddedString();
                StringToDateTime();
                done.Signal();
            });

            done.Wait();
        }
    }
}
