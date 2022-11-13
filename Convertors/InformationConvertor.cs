using ABSAConversionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAConversionLib
{
    // Concrete product
    public class InformationConvertor : IConvertor
    {
        public Output _output = new Output();
        private Input _input;
        private decimal _outputValue;
        public Output Convert(Input input)
        {
            try
            {
                _input = input;
                decimal valueToConvert = _input._value.StringToDecimalTryCatch();

                decimal inDefaultUnit = valueToConvert / GetDefaultUnitRatio(_input._units);
                _outputValue = inDefaultUnit * GetDefaultUnitRatio(_input._convertTo);

                _input._units = GetProperInputUnitName();
                return new Output(_outputValue.ToString(), GetProperOutputUnitName(), _input);
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}");
            }
        }
        private decimal GetDefaultUnitRatio(string unitIdentificator)
        {
            decimal unitDefaultRatio = 1;
            foreach (InformationUnit unit in ConversionLib._informationUnitDefinitions)
                if (unit._identificationStrings.Contains(unitIdentificator))
                    unitDefaultRatio = unit.ratioToDefaultUnit;
            return unitDefaultRatio;
        }

        private string GetUnitName(string unitIdentifier)
        {
            string unitName = "";
            foreach (InformationUnit unit in ConversionLib._informationUnitDefinitions)
                if (unit._identificationStrings.Contains(unitIdentifier))
                    unitName = unit._name;
            return unitName;
        }
        private string GetProperInputUnitName()
        {
            string unitName = "";
            foreach (InformationUnit unit in ConversionLib._informationUnitDefinitions)
                if (unit._identificationStrings.Contains(_input._units))
                {
                    if (_input._value.StringToDecimalTryCatch() <= 1)
                        unitName = unit._name;
                    else
                        unitName = unit._plural;
                }
            return unitName;
        }
        private string GetProperOutputUnitName()
        {
            string unitName = "";
            foreach (InformationUnit unit in ConversionLib._informationUnitDefinitions)
                if (unit._identificationStrings.Contains(_input._convertTo))
                {
                    if (_outputValue <= 1)
                        unitName = unit._name;
                    else
                        unitName = unit._plural;
                }
            return unitName;
        }
    }
    public class InformationUnit
    {
        public string _name;
        public decimal ratioToDefaultUnit;
        public string _plural;
        public string _symbol;

        public List<string> _identificationStrings = new List<string>();

        public InformationUnit(string name, decimal relevanceToDefaultUnit, string plural, string symbol)
        {
            _name = name;
            ratioToDefaultUnit = relevanceToDefaultUnit;
            _plural = plural;
            _symbol = symbol;
            _identificationStrings.Add(_name);
            _identificationStrings.Add(_plural);
            _identificationStrings.Add(_symbol);
        }
    }
}
