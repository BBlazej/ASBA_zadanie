# ASBA_zadanie

Possible conversions:

```
Length: meter/inch/foot (m/ft/in)
Temperature: Fahrenheit/Celsius (F/C)
Information: Bit/Byte (bit/B)

Using of plural in units definitions is allowed.
Definitions of units are not case-sensitive.
```

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

// Output class have overrided ToString method in format: 
// "(inputValue inputUnits) -> outputValue outputUnits"
// Or if input data are not present
// "(outputValue outputUnits)"
```
