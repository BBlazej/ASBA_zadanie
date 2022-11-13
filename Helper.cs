using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAConversionLib
{
    public static class Helper
    {
        static public decimal StringToDecimalTryCatch(this string stringToConvert)
        {
            try
            {
                return decimal.Parse(stringToConvert);
            }
            catch (Exception ex)
            {
                throw new Exception($@"{ex.Message}", ex);
            }
        }
        static public decimal? StringToDecimal(this string stringToConvert)
        {
            decimal output = 0;

            if (!decimal.TryParse(stringToConvert, out output))
                return null;

            Console.WriteLine($@"StringToDecimal returns {output}");
            return output;
        }

        static public void GetHelp()
        {
            Console.WriteLine("Library usage explanation...");
        }
    }
}
