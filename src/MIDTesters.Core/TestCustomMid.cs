using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Converters;
using OpenProtocolInterpreter.Time;
using System;
using System.Collections.Generic;

namespace MIDTesters.Core
{
    [TestClass]
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
            Assert.AreEqual($"00390081            {Now:yyyy-MM-dd:HH:mm:ss}", mid.Pack());
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
            Assert.AreEqual(pack, mid.Pack());
        }
    }

    public class OverridedMid0081 : Mid0081
    {
        public string FormattedDate
        {
            get => Time.ToString("dd/MM/yyyy HH:mm:ss");
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
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 83;

        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        public string TimeZone
        {
            get => GetField(1, (int)DataFields.TIMEZONE).Value;
            set => GetField(1, (int)DataFields.TIMEZONE).SetValue(value);
        }

        public NewMid0083() : base(MID, LAST_REVISION)
        {
            _dateConverter = new DateConverter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TIME, 20, 19),
                                new DataField((int)DataFields.TIMEZONE, 41, 2)
                            }
                }
            };
        }

        public enum DataFields
        {
            TIME,
            TIMEZONE
        }
    }
}
