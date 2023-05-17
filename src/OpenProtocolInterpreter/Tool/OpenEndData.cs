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
    }
}
