namespace ABSAConversionLib
{
    // Concrete product
    public class LengthConvertor : Convertor
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

                decimal inDefaultUnit = valueToConvert / GetDefaultUnitRatio(_input._units, ConversionLib._lengthUnitDefinitions);
                _outputValue = inDefaultUnit * GetDefaultUnitRatio(_input._convertTo, ConversionLib._lengthUnitDefinitions);

                _input._units = GetProperInputUnitName(ConversionLib._lengthUnitDefinitions);
                return new Output(_outputValue.ToString(), GetProperOutputUnitName(ConversionLib._lengthUnitDefinitions, _outputValue), _input);
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }
    }
}
