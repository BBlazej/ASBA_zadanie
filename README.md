# ASBA_zadanie
Units Convertor Usage: 

```csharp
using ABSAConversionLib;

ConversionLib lib = new ConversionLib();

// input as List<string> {inputValue inputUnits, outputUnits}
string[] input1s = { "2 meters", "feet" };
var input1 = new List<string>(input1s);
Console.WriteLine($@"{lib.Convert(input1)}");

// input as string {"inputValue inputUnits, outputUnits"}
string Sinput1 = $@"(1 meter, feet)";
Console.WriteLine($@"{lib.Convert(Sinput1)}");
```
