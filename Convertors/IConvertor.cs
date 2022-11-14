namespace ABSAConversionLib
{
    // Product interface
    public interface IConvertor
    {
        public Output Convert(Input input);
    }

    public class Convertor : IConvertor
    {
        Input _input = new Input();
        public virtual Output Convert(Input input)
        {
            return new Output();
        }

        protected virtual string GetProperInputUnitName(List<Unit> unitsDefinitions)
        {
            string unitName = "";
            foreach (Unit unit in unitsDefinitions)
                if (unit._identificationStrings.Contains(_input._units))
                {
                    if (_input._value.StringToDecimalTryCatch() <= 1)
                        unitName = unit._name;
                    else
                        unitName = unit._plural;
                }
            return unitName;
        }
        protected virtual string GetProperOutputUnitName(List<Unit> unitsDefinitions, decimal outputValue)
        {
            string unitName = "";
            foreach (Unit unit in unitsDefinitions)
                if (unit._identificationStrings.Contains(_input._convertTo))
                {
                    if (outputValue <= 1)
                        unitName = unit._name;
                    else
                        unitName = unit._plural;
                }
            return unitName;
        }
        protected virtual string GetUnitName(string unitIdentifier, List<Unit> unitsDefinitions)
        {
            string unitName = "";
            foreach (Unit unit in unitsDefinitions)
                if (unit._identificationStrings.Contains(unitIdentifier))
                    unitName = unit._name;
            return unitName;
        }
        protected virtual decimal GetDefaultUnitRatio(string unitIdentificator, List<Unit> unitsDefinitions)
        {
            decimal unitDefaultRatio = 1;
            foreach (Unit unit in unitsDefinitions)
                if (unit._identificationStrings.Contains(unitIdentificator))
                    unitDefaultRatio = unit.ratioToDefaultUnit;
            return unitDefaultRatio;
        }
    }
}
