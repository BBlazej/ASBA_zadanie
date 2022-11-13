// See https://aka.ms/new-console-template for more information
using ABSAConversionLib;


ConversionLib lib = new ConversionLib();


string[] input1s = { "feet" };
string[] input2s = { "2 m", "ft" };
string[] input3s = { "2 m", "feet" };
string[] input4s = { "2 feedddt", "m" };
string[] input5s = { "2 inches", "m" };
string[] input6s = { "2 feet", "inches" };

var input1 = new List<string>(input1s);
var input2 = new List<string>(input2s);
var input3 = new List<string>(input3s);
var input4 = new List<string>(input4s);
var input5 = new List<string>(input5s);
var input6 = new List<string>(input6s);

Console.WriteLine($@"Length conversion.");
Console.WriteLine($@"List<string> input.");
Console.WriteLine($@"{lib.Convert(input1)}");
Console.WriteLine($@"{lib.Convert(input2)}");
Console.WriteLine($@"{lib.Convert(input3)}");
Console.WriteLine($@"{lib.Convert(input4)}");
Console.WriteLine($@"{lib.Convert(input5)}");
Console.WriteLine($@"{lib.Convert(input6)}");


string Sinput1 = $@"(1 meter, feet)";

Console.WriteLine($@"String input.");
Console.WriteLine($@"{lib.Convert(Sinput1)}");

Console.WriteLine($@"Temperature conversion.");
string Sinput2 = $@"(20 C, F)";
string Sinput3 = $@"(60 Fahrenheit, Celsius)";
Console.WriteLine($@"{lib.Convert(Sinput2)}");
Console.WriteLine($@"{lib.Convert(Sinput3)}");


Console.WriteLine($@"Information conversion.");
string Sinput4 = $@"(8 Bits, B)";
string Sinput5 = $@"(40 bit, Bytes)";
Console.WriteLine($@"{lib.Convert(Sinput4)}");
Console.WriteLine($@"{lib.Convert(Sinput5)}");

Console.WriteLine($@"Done.");
