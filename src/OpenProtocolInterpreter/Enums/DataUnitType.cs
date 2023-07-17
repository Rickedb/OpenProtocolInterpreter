using System;

namespace OpenProtocolInterpreter
{
    public enum DataUnitType
    {
        NoUnit = 0,

        //Torque units
        /// <summary>
        /// Newton meter
        /// </summary>
        Nm = 1,
        /// <summary>
        /// Foot-pound force
        /// </summary>
        FtLbf = 2,
        /// <summary>
        /// Centi Newton meter
        /// </summary>
        CNm = 3,
        /// <summary>
        /// Kilo Newton meter
        /// </summary>
        KNm = 4,
        /// <summary>
        /// Mega Newton meter
        /// </summary>
        MNm = 5,
        /// <summary>
        /// Inch-pound force
        /// </summary>
        InLbf = 6,
        /// <summary>
        /// Kilo pound meter
        /// </summary>
        Kpm = 7,
        /// <summary>
        /// Kilo centi force
        /// </summary>
        [Obsolete]
        Kfcnm = 8,
        [Obsolete]
        TorquePercentage = 9,
        OzfIn = 10,
        DNm = 11,
        /// <summary>
        /// Milli-newton meter
        /// </summary>
        MiNm = 12,
        /// <summary>
        /// Kilogram force centimeter
        /// </summary>
        KgfCm = 13,
        /// <summary>
        /// Gram force centimeter
        /// </summary>
        GfCm = 14,
        /// <summary>
        /// Ounce force foot
        /// </summary>
        FtOzf = 15,

        //Angle units
        Degree = 50,
        Radian = 51,

        //Frequency units
        /// <summary>
        /// Hertz
        /// </summary>
        Hz = 100,
        /// <summary>
        /// Revolutions per minute
        /// </summary>
        Rpm = 101,

        //Torque rate units
        /// <summary>
        /// Newton meter / degree
        /// </summary>
        NmByDegree = 150,
        /// <summary>
        /// Foot-pound force / degree
        /// </summary>
        FtLbfByDegree = 151,
        /// <summary>
        /// Centi Newton meter / degree
        /// </summary>
        CNmByDegree = 152,
        /// <summary>
        /// Kilo Newton meter / degree
        /// </summary>
        KNmByDegree = 153,
        /// <summary>
        /// Mega Newton meter / degree
        /// </summary>
        MNmByDegree = 154,
        /// <summary>
        /// Inch-pound force / degree
        /// </summary>
        InLbfByDegree = 155,

        /// <summary>
        /// Newton meter / radian
        /// </summary>
        NmByRadian = 160,
        /// <summary>
        /// Foot-pound force / radian
        /// </summary>
        FtLbfByRadian = 161,
        /// <summary>
        /// Centi Newton meter / radian
        /// </summary>
        CNmByRadian = 162,

        //Time units
        Second = 200,
        Minute = 201,
        Milliseconds = 202,
        Hour = 203,

        //Temperature units
        Kelvin = 250,
        Celsius = 251,
        Fahrenheit = 252,

        //Force units
        /// <summary>
        /// Newton
        /// </summary>
        N = 300,
        /// <summary>
        /// Kilo newton
        /// </summary>
        KN = 301,
        /// <summary>
        /// Pound-force
        /// </summary>
        Lbf = 302,
        /// <summary>
        /// Kilogram-force
        /// </summary>
        Kgf = 303,
        /// <summary>
        /// Ounce-force
        /// </summary>
        Ozf = 304,
        /// <summary>
        /// Mega newton
        /// </summary>
        MN = 305,

        //Length units
        Meter = 350,
        Millimeter = 351,
        Inch = 352,

        //Speed units
        MeterPerSecond = 400,
        MillimeterPerSecond = 401,

        //Force rate units
        /// <summary>
        /// Newton / millimeter
        /// </summary>
        NByMm = 450,
        /// <summary>
        /// Kilo newton / millimeter
        /// </summary>
        KNByMm = 451,
        /// <summary>
        /// Pound-force / inch
        /// </summary>
        LbfByIn = 452,
        /// <summary>
        /// Kilogram-force / millimeter
        /// </summary>
        KgfByMm = 453,
        /// <summary>
        /// Ounce-force / inch
        /// </summary>
        OzfByIn = 454,
        /// <summary>
        /// Mega newton / millimeter
        /// </summary>
        MNByMm = 455,

        //Acceleration units
        MeterPerSecondSquared = 500,
        MillimeterPerSecondSquared = 501,

        //Mass units
        /// <summary>
        /// Kilogram
        /// </summary>
        Kg = 550,
        /// <summary>
        /// Pound
        /// </summary>
        Lb = 551,

        //Volume units
        Liter = 600,
        CubicMeter = 601,

        //Area units
        SquareMeter = 650,

        //Power units
        Watt = 700,

        //Electric units
        Ampere = 750,
        Volt = 751,
        Ohm = 752,
        Farad = 753,
        Henry = 754,

        //Other units
        Percentage = 800,

        //Pressure units
        /// <summary>
        /// Kilo pascal
        /// </summary>
        KPa = 850,

        //Plotting units
        /// <summary>
        /// Y = Newton meter, X = milliseconds
        /// </summary>
        NmByMilliseconds = 900,
        /// <summary>
        /// Y = foot-pound force, X = milliseconds
        /// </summary>
        FtLbfByMilliseconds = 901,
        /// <summary>
        /// Y = centi Newton meter, X = milliseconds
        /// </summary>
        CNmByMilliseconds = 902,
        /// <summary>
        /// Y = kilo Newton meter, X = milliseconds
        /// </summary>
        KNmByMilliseconds = 903,
        /// <summary>
        /// Y = mega Newton meter, X = milliseconds
        /// </summary>
        MNmByMilliseconds = 904,
        /// <summary>
        /// Y = inch-pound force, X = milliseconds
        /// </summary>
        InLbfByMilliseconds = 905,

        /// <summary>
        /// Y = Degree, X = milliseconds
        /// </summary>
        DegreeByMilliseconds = 910,
        /// <summary>
        /// Y = Radian, X = milliseconds
        /// </summary>
        RadianByMilliseconds = 911,

        /// <summary>
        /// Y = newton, X = milliseconds
        /// </summary>
        NByMilliseconds = 920,
        /// <summary>
        /// Y = kilo newton, X = milliseconds
        /// </summary>
        KNByMilliseconds = 921,
        /// <summary>
        /// Y = pound-force, X = milliseconds
        /// </summary>
        LbfByMilliseconds = 922,
        /// <summary>
        /// Y = kilogram-force, X = milliseconds
        /// </summary>
        KgfByMilliseconds = 923,
        /// <summary>
        /// Y = ounce-force, X = milliseconds
        /// </summary>
        OzfByMilliseconds = 924,
        /// <summary>
        /// Y = mega newton, X = milliseconds
        /// </summary>
        MNByMilliseconds = 925

    }
}
