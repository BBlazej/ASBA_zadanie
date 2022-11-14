using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAConversionLib
{
    public class Input
    {
        public string _value = "";
        public string _units = "";
        public string _convertTo = "";
        public bool _valid = false;
        private int _argCount = 0;
        private object _inputObject;

        public Input() { }
        public Input(object inputObject) 
        {
            _inputObject = inputObject;
            if (inputObject is List<string>)
                ParseListInput((List<string>)inputObject);
            else if (inputObject is string)
                ParseStringInput((string)inputObject);
            else
            {
                Helper.GetHelp();
                Console.WriteLine($@"Error: Not supported input type: {inputObject.GetType}.", "");
                return;
            }
        }
        void ParseStringInput(string input)
        {
            string inp = input;
            inp = inp.Replace('(', ' ').Replace(')', ' ').Trim();
            List<string> list = new List<string>();
            list = inp.Split(",").ToList();
            ParseListInput(list);
        }

        void ParseListInput(List<string> input)
        {
            if (input == null)
            {
                Console.WriteLine($@"Error: Provided input is null.");
                return;
            }

            _argCount = input.Count;

            if (!ValidateArguments())
                return;

            _value = input[0].Split(" ")[0].Trim();
            _units = input[0].Split(" ")[1].Trim();
            _convertTo = input[1].Trim();
        }

        bool ValidateArguments()
        {
            try
            {
                bool inputValidation = false;
                switch (_argCount)
                {
                    case 0:
                        Console.WriteLine($@"Error: Input List is empty.");
                        inputValidation = false;
                        break;
                    case 1:
                        Console.WriteLine($@"Error: Input List has only one argument.");
                        inputValidation = false;
                        break;
                    case 2:
                        inputValidation = true;
                        _valid = true;
                        break;
                }
                return inputValidation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override string ToString()
        {
            return $@"({_inputObject})";
        }
    }
}
