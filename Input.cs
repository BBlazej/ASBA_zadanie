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
        private int argCount = 0;

        public Input() { }
        public Input(List<string> input)
        {
            ParseListInput(input);
        }
        public Input(string input)
        {

            string inp = input;
            inp = inp.Replace('(', ' ').Replace(')', ' ').Trim();
            List<string> list = new List<string>();
            list = inp.Split(",").ToList();
            ParseListInput(list);
        }

        void ParseListInput(List<string> input)
        {
            // ("1 meter", "feet")-> "3.28 feet"
            if (input == null)
            {
                Console.WriteLine($@"Error: Provided input is null.");
                return;
            }

            argCount = input.Count;

            if (!ValidatedInput())
                return;

            _value = input[0].Split(" ")[0].Trim();
            _units = input[0].Split(" ")[1].Trim();
            _convertTo = input[1].Trim();

        }

        bool ValidatedInput()
        {
            try
            {
                bool inputValidation = false;
                
                switch (argCount)
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
    }
}
