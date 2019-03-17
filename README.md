# CsvNet
CSV Serializer &amp; Deserializer for C#

## Getting Started
A basic use of the project something like this...
```csharp
using CsvNet;
using System.Globalization;
using System.IO;

void Main()
{
    //Read string lines csv file
    var lines = File.ReadLines(@"path\to\file.csv");
    
    //Get collection from string lines
    IEnumerable<Foo> collection = CsvConvert.Deserialize<Foo>(lines, CultureInfo.CurrentCulture);
}
```
```csharp
using CsvNet;
using System;
using System.Globalization;

void Main()
{
    IEnumerable<Foo> collection = ...
    
    //Get string text from collection
    string text = CsvConvert.Serialize(collection, CultureInfo.CurrentCulture);
    
    Console.WriteLine(text);
}
```
