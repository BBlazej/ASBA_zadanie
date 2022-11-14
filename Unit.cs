namespace ABSAConversionLib
{
    public class Unit
    {
        public string _name;
        public decimal ratioToDefaultUnit;
        public string _plural;
        public string _symbol;

        public List<string> _identificationStrings = new List<string>();

        public Unit(string name, decimal relevanceToDefaultUnit, string plural, string symbol)
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
