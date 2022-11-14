namespace ABSAConversionLib
{ 
    // Concrete product
    public class TemperatureConvertor : Convertor
    {
        public Output _output = new Output();
        private Input _input = new Input();
        private decimal _outputValue;
        public override Output Convert(Input input)
        {
            try
            {
                _input = input;
                decimal valueToConvert = _input._value.StringToDecimalTryCatch();
                string inputUnitName = GetUnitName(_input._units, ConversionLib._temperaturehUnitDefinitions);
                string outputUnitName = GetUnitName(_input._convertTo, ConversionLib._temperaturehUnitDefinitions);

                if (inputUnitName == outputUnitName)
                    _outputValue = valueToConvert;
                else if (inputUnitName == "Celsius" && outputUnitName == "Fahrenheit")
                    _outputValue = valueToConvert * 1.8m + 32;
                else if (inputUnitName == "Fahrenheit" && outputUnitName == "Celsius")
                    _outputValue = (valueToConvert - 32) / 1.8m;

                _input._units = GetProperInputUnitName(ConversionLib._temperaturehUnitDefinitions);
                return new Output(_outputValue.ToString(), GetProperOutputUnitName(ConversionLib._temperaturehUnitDefinitions, _outputValue));
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }
    }
}
