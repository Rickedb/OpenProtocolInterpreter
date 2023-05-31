namespace OpenProtocolInterpreter.Tool
{
    public class OpenEndData
    {
        public bool UseOpenEnd { get; set; }
        public TighteningDirection TighteningDirection { get; set; }
        public MotorRotation MotorRotation { get; set; }

        public OpenEndData()
        {

        }

        public OpenEndData(bool useOpenEnd, TighteningDirection tighteningDirection, MotorRotation motorRotation)
        {
            UseOpenEnd = useOpenEnd;
            TighteningDirection = tighteningDirection;
            MotorRotation = motorRotation;
        }

        public string Pack()
        {
            return OpenProtocolConvert.ToString(UseOpenEnd) +
                    OpenProtocolConvert.ToString((int)TighteningDirection) +
                    OpenProtocolConvert.ToString((int)MotorRotation);
        }

        public static OpenEndData Parse(string value)
        {
            return new OpenEndData()
            {
                UseOpenEnd = OpenProtocolConvert.ToBoolean(value[0].ToString()),
                TighteningDirection = (TighteningDirection)OpenProtocolConvert.ToInt32(value[1].ToString()),
                MotorRotation = (MotorRotation)OpenProtocolConvert.ToInt32(value[2].ToString()),
            };
        }
    }
}
