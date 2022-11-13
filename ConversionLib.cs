

using static ABSAConversionLib.TemperatureConvertor;

namespace ABSAConversionLib
{
    /*
     * Create a class library (C#) for conversion of quantities between different units. 
     * The library should provide conversions between units of length (meters, feet, inches), 
     * units of data (bits or bytes) 
     * and temperature (celsius , fahrenheit) out of the box. 
     * The library must support commonly used SI prefixes.
     *   
     * The library must be easily extensible so that conversions of units of other measures (like volume - liter, cubicinch, pint) 
     * could be added by someone else in the future.
     * 
     * API must provide functions that take text input with some kind of simplified syntax (ignore plural / singular difference for example).
     * 
     * Example input  (from X units, to target unit)-> output:
     * ("1 meter", "feet") -> "3.28 feet"
     * ("3 kiloinches", "meter") -> "76.19 meter"
     * 
     * Input / output are not defined strictly. We don't care about 100% correct english grammar 
     * (like correct plural / singular form – "2 inch" is OK). It is up to candidate to come up with some reasonable syntax rules.
     * 
     * Couple of criteria and hints:
     * 
     * Solution must be in production quality. 
     * Fellow programmer doing changes to your code must feel safe not to break it accidentally.
     * 
     * Important factor is flexibility and code clarity! 
     * 
     * Don't over-engineer but don't under-engineer
     */

    public class ConversionLib
    {
        Input _input = null;
        public Output _output = null;
        bool _initialized = false;

        public static List<LengthUnit> _lengthUnitDefinitions = new List<LengthUnit>();
        public static List<TemperatureUnit> _temperaturehUnitDefinitions = new List<TemperatureUnit>();
        public static List<InformationUnit> _informationUnitDefinitions = new List<InformationUnit>();

        List<string> _lengthIdentificationStrings = new List<string>();
        List<string> _temperatureIdentificationStrings = new List<string>();
        List<string> _informationIdentificationStrings = new List<string>();

        public Output Convert(object input)
        {
            try
            {
                if (!_initialized)
                {
                    InitializeUnitsDefinitions();
                    InitializeUnitsIdentificationStrings();
                }
                _initialized = true;

                if (input is List<string>)
                    _input = new Input((List<string>)input);
                else if (input is string)
                    _input = new Input((string)input);
                else
                {
                    Helper.GetHelp();
                    return new Output($@"Error: Not supported input type: {_input.GetType}.", "");
                }

                if (!_input._valid)
                {
                    Helper.GetHelp();
                    return new Output($@"Error: Input arguments are not valid.", "");
                }

                int inputUnitsType = ValidateInputTypes();
                if (inputUnitsType == -1)
                {
                    Helper.GetHelp();
                    return new Output($@"Error: Input contains different/not defined Units to convert.", "");
                }

                if (inputUnitsType == (int)UnitType.Length)
                    return Convert(new LengthConvertorCreator());
                else if (inputUnitsType == (int)UnitType.Temperature)
                    return Convert(new TemperatureConvertorCreator());
                else if (inputUnitsType == (int)UnitType.Information)
                    return Convert(new InformationConvertorCreator());

                Helper.GetHelp();
                return new Output($@"Error: Not defined conversion type.", "");
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }

        void InitializeUnitsDefinitions()
        {
            _lengthUnitDefinitions.Add(new LengthUnit("meter", 1, "meters", "m"));
            _lengthUnitDefinitions.Add(new LengthUnit("foot", 3.28084m, "feet", "ft"));
            _lengthUnitDefinitions.Add(new LengthUnit("inch", 39.37008m, "inches", "in"));

            _temperaturehUnitDefinitions.Add(new TemperatureUnit("Celsius", 1, "C", "C"));
            _temperaturehUnitDefinitions.Add(new TemperatureUnit("Fahrenheit", 1, "F", "F"));

            _informationUnitDefinitions.Add(new InformationUnit("Bit", 8, "Bits", "bit"));
            _informationUnitDefinitions.Add(new InformationUnit("Byte", 1, "Bytes", "B"));
        }

        void InitializeUnitsIdentificationStrings()
        {
            foreach (LengthUnit unit in _lengthUnitDefinitions)
                _lengthIdentificationStrings.AddRange(unit._identificationStrings);
            foreach (TemperatureUnit unit in _temperaturehUnitDefinitions)
                _temperatureIdentificationStrings.AddRange(unit._identificationStrings);
            foreach (InformationUnit unit in _informationUnitDefinitions)
                _informationIdentificationStrings.AddRange(unit._identificationStrings);
        }

        private int ValidateInputTypes()
        {
            string units = _input._units;
            string convertTo = _input._convertTo;

            if (_lengthIdentificationStrings.Contains(units) && _lengthIdentificationStrings.Contains(convertTo))
                return (int)UnitType.Length;
            if (_temperatureIdentificationStrings.Contains(units) && _temperatureIdentificationStrings.Contains(convertTo))
                return (int)UnitType.Temperature;
            if (_informationIdentificationStrings.Contains(units) && _informationIdentificationStrings.Contains(convertTo))
                return (int)UnitType.Information;
            return -1;
        }

        public Output Convert(Convertor convertor)
        {
            return convertor.Convert(_input);
        }
        public enum UnitType
        {
            Length = 0,
            Temperature = 1,
            Information = 2
        }
    }
}