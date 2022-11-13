using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAConversionLib
{
    public class Output
    {
        public string _outputValue = "";
        public string _outputUnits = "";
        public Input _input;

        public Output() { }
        public Output(string outputValue, string outputUnits, Input input = null)
        {
            _outputValue = outputValue;
            _outputUnits = outputUnits;
            _input = input;
        }   

        public override string ToString()
        {
            if (_input != null)
                return $@"({_input._value} {_input._units}) -> {_outputValue} {_outputUnits}";
            else
                return $@"({_outputValue} {_outputUnits}";
        }
    }  
}
