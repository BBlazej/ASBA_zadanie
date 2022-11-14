namespace ABSAConversionLib
{
    // Concrete product
    public class InformationConvertor : Convertor
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

                decimal inDefaultUnit = valueToConvert / GetDefaultUnitRatio(_input._units, ConversionLib._informationUnitDefinitions);
                _outputValue = inDefaultUnit * GetDefaultUnitRatio(_input._convertTo, ConversionLib._informationUnitDefinitions);

                _input._units = GetProperInputUnitName(ConversionLib._informationUnitDefinitions);
                return new Output(_outputValue.ToString(), GetProperOutputUnitName(ConversionLib._informationUnitDefinitions, _outputValue), _input);
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }
    }
}
