namespace OpenProtocolInterpreter.Enums
{
    public enum DataTypeDefinition
    {
        /// <summary>
        /// <c>UI</c> - The value is an unsigned integer. The number of digits are defined with the Length parameter
        /// </summary>
        UnsignedInteger = 1,
        /// <summary>
        /// <c>I</c> - The value is a signed integer. The number of digits are defined with the Length parameter
        /// </summary>
        Integer = 2,
        /// <summary>
        /// <para><c>F</c> - The value is sent as a float value with the layout <c>12.12</c>, <c>10025.1234</c> or <c>-57.5</c>.</para>
        /// <para>It is up to the sender of the telegram to decide the number of decimals to send.</para>
        /// The number of characters sent varies depending on the size and resolution of the sent number.
        /// </summary>
        Float = 3,
        /// <summary>
        /// <para><c>S</c> - The value is a string. Sent as ASCII characters, the length of the data fits the actual length of the string. </para>
        /// <em>Note that the string may contain spaces (ASCII character 0x20)</em> 
        /// </summary>
        String = 4,
        /// <summary>
        /// <c>S</c> - A time specified by 19 ASCII characters (<c>YYYY-MM-DD:HH:MM:SS</c>)
        /// </summary>
        Timestamp = 5,
        /// <summary>
        /// <para><c>B</c> - A boolean value, one ASCII digit:</para>
        /// <example>0 = FALSE | 1 = TRUE</example>
        /// </summary>
        Boolean = 6,
        /// <summary>
        /// <c>H</c> - Hexadecimal value. Sent as ASCII characters, example: <c>A24CD3</c>.
        /// </summary>
        Hexadecimal = 7,
        /// <summary>
        /// <c>PL1</c> - Plotting point consisting of a FA of one pair of float values where the first value is the Y and the second is the X within the pair.
        /// </summary>
        PlottingPoint1 = 8,
        /// <summary>
        /// <c>PL2</c> - Plotting point consisting of a FA of two pairs of float values where the first value is the Y and the second is the X within a pair.
        /// </summary>
        PlottingPoint2 = 9,
        /// <summary>
        /// <c>PL4</c> - Plotting point consisting of a FA of 4 pairs of float values where the first value is the Y and the second is the X within a pair.
        /// </summary>
        PlottingPoint4 = 10,
        /// <summary>
        /// <para><c>FA</c> - Array of Float. Each float value is sent as 8 ASCII characters.</para> 
        /// <para>Negative values start with a ‘-‘ sign. The precision of the values vary, for large values decimal point is omitted.</para>
        /// <para>Valid values are for example <c>-1234567</c>, <c>001.1205</c>, <c>-123.789</c></para>
        /// </summary>
        FloatArray = 50,
        /// <summary>
        /// <para><c>UA</c> - Array of Unsigned integers. Each integer value is sent as 8 ASCII characters.</para> 
        /// <para>Valid values are for example <c>12345678</c>, <c>00001234</c>, <c>00200000</c></para>
        /// </summary>
        UnsignedIntegerArray = 51,
        /// <summary>
        /// <para><c>IA</c> - Array of Signed integers. Each integer value is sent as 8 ASCII characters. Negative values start with a ‘-‘ sign.</para> 
        /// <para>Valid values are for example <c>12345678</c>, <c>-1234567</c>, <c>00200000</c>, <c>10200000</c></para>
        /// </summary>
        IntegerArray = 52
    }
}
