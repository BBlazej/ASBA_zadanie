namespace ABSAConversionLib
{
    public class ConversionLib
    {
        Input _input = null;
        public Output _output = null;

        public static List<Unit> _lengthUnitDefinitions = new List<Unit>();
        public static List<Unit> _temperaturehUnitDefinitions = new List<Unit>();
        public static List<Unit> _informationUnitDefinitions = new List<Unit>();

        List<string> _lengthIdentificationStrings = new List<string>();
        List<string> _temperatureIdentificationStrings = new List<string>();
        List<string> _informationIdentificationStrings = new List<string>();


        public ConversionLib()
        {
            InitializeUnitsDefinitions();
            InitializeUnitsIdentificationStrings();
        }

        public Output Convert(object input)
        {
            try
            {
                _input = new Input(input);
                if (!_input._valid)
                {
                    Helper.GetHelp();
                    return new Output($@"Error: Input arguments are not valid. {_input}", "");
                }

                int unitConversionType = GetUnitConversionType();
                if (unitConversionType == -1)
                {
                    Helper.GetHelp();
                    return new Output($@"Error: Input contains different/not defined Units to convert. {_input}", "");
                }

                if (unitConversionType == (int)UnitType.Length)
                {
                    LengthConvertor convertor = new LengthConvertor();
                    return convertor.Convert(_input);
                }
                else if (unitConversionType == (int)UnitType.Temperature)
                {
                    TemperatureConvertor convertor = new TemperatureConvertor();
                    return convertor.Convert(_input);
                }
                else if (unitConversionType == (int)UnitType.Information)
                {
                    InformationConvertor convertor = new InformationConvertor();
                    return convertor.Convert(_input);
                }

                Helper.GetHelp();
                return new Output($@"Error: Not defined conversion type. {_input}", "");
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }

        void InitializeUnitsDefinitions()
        {
            _lengthUnitDefinitions.Add(new Unit("meter", 1, "meters", "m"));
            _lengthUnitDefinitions.Add(new Unit("foot", 3.28084m, "feet", "ft"));
            _lengthUnitDefinitions.Add(new Unit("inch", 39.37008m, "inches", "in"));

            _temperaturehUnitDefinitions.Add(new Unit("Celsius", 1, "C", "C"));
            _temperaturehUnitDefinitions.Add(new Unit("Fahrenheit", 1, "F", "F"));

            _informationUnitDefinitions.Add(new Unit("Bit", 8, "Bits", "bit"));
            _informationUnitDefinitions.Add(new Unit("Byte", 1, "Bytes", "B"));
        }

        void InitializeUnitsIdentificationStrings()
        {
            foreach (Unit unit in _lengthUnitDefinitions)
                _lengthIdentificationStrings.AddRange(unit._identificationStrings);
            foreach (Unit unit in _temperaturehUnitDefinitions)
                _temperatureIdentificationStrings.AddRange(unit._identificationStrings);
            foreach (Unit unit in _informationUnitDefinitions)
                _informationIdentificationStrings.AddRange(unit._identificationStrings);
        }

        private int GetUnitConversionType()
        {
            if (_lengthIdentificationStrings.Contains(_input._units) && _lengthIdentificationStrings.Contains(_input._convertTo))
                return (int)UnitType.Length;
            if (_temperatureIdentificationStrings.Contains(_input._units) && _temperatureIdentificationStrings.Contains(_input._convertTo))
                return (int)UnitType.Temperature;
            if (_informationIdentificationStrings.Contains(_input._units) && _informationIdentificationStrings.Contains(_input._convertTo))
                return (int)UnitType.Information;
            return -1;
        }
        
        public enum UnitType
        {
            Length = 0,
            Temperature = 1,
            Information = 2
        }
    }
}