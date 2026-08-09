using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MIDTesters
{
    [TestClass]
    [TestCategory("Customization")]
    public class TestCustomMid : MidTester
    {
        public static DateTime Now;

        public TestCustomMid()
        {
            Now = DateTime.Now;
        }

        [TestMethod]
        public void OverrideMid0081()
        {
            _midInterpreter.UseTimeMessages(new Dictionary<int, Type>() { { 81, typeof(OverridedMid0081) } });

            string pack = @"00390081            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<OverridedMid0081>(pack);

            Assert.AreEqual(typeof(OverridedMid0081), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.FormattedDate);
            Assert.AreEqual(mid.FormattedDate, "01/12/2017 20:12:45");
            AssertEqualPackages($"00390081            {Now:yyyy-MM-dd:HH:mm:ss}", mid, true);
        }

        [TestMethod]
        public void AddNewCustomMid()
        {
            _midInterpreter.UseCustomMessage(new Dictionary<int, Type>() { { 83, typeof(NewMid0083) } });

            string pack = @"00450083            012017-12-01:20:12:4502-3";
            var mid = _midInterpreter.Parse<NewMid0083>(pack);

            Assert.AreEqual(typeof(NewMid0083), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.TimeZone);
            AssertEqualPackages(pack, mid, true);
        }
    }

    public class OverridedMid0081 : Mid0081
    {
        public string FormattedDate
        {
            get => Time.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            set => Time = DateTime.Parse(value);
        }

        public OverridedMid0081()
        {

        }

        public override string Pack()
        {
            Time = TestCustomMid.Now;
            return base.Pack();
        }
    }

    public class NewMid0083 : Mid
    {
        private const int LAST_REVISION = 1;
        public const int MID = 83;

        [TimestampDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 19)]
        public DateTime Time { get; set; }
        [StringDataFieldDefinition(revision: 1, field: 2, Index = 41, Size = 2)]
        public string TimeZone { get; set; }
        public NewMid0083() : base(MID, LAST_REVISION)
        {
        }
    }
}
