# CsvSharp

CSV Serializer &amp; Deserializer for C#

## Installation

**``Csv.Csharp`` is available on NuGet** [![NuGet](https://img.shields.io/nuget/v/Csv.Csharp.svg)](https://www.nuget.org/packages/Csv.Csharp/)

```console
PM> Install-Package Csv.Csharp -version 1.0.3
```

## Getting Started

A basic use of the project something like this...

``genius.csv`` without column names

```csv
Galileu;Galilei;1564-02-15
Isaac;Newton;1643-04-01
Albert;Einstein;1879-03-13
```

``Genius class``

```csharp
using CsvSharp.Attributes;

public class Genius
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
	
    [CsvDateTimeFormat("yyyy-MM-dd")]
    public DateTime BirthDate { get; set; }
}
```

```csharp
using CsvSharp;
using System.Globalization;
using System.IO;

void Main()
{
    //Read string lines csv file
    var lines = File.ReadLines(@"path\to\file.csv");
    
    //Get collection from string lines
    IEnumerable<Genius> collection = CsvConvert.Deserialize<Genius>(lines, CultureInfo.InvariantCulture);
}
```

``Result list``

| FirstName | LastName |      BirthDate       |
|:---------:|:--------:|:--------------------:|
| Galileu   | Galilei  | 1564-02-15 00:00:00  |
| Isaac     | Newton   | 1643-04-01 00:00:00  |
| Albert    | Einstein | 1879-03-13 00:00:00  |

```csharp
using CsvSharp;
using System;
using System.Globalization;

void Main()
{
    IEnumerable<Genius> collection = ...
    
    //Get string text from collection
    string text = CsvConvert.Serialize(collection, CultureInfo.InvariantCulture);
    
    Console.WriteLine(text);
}
```

``Result text``

```csv
Galileu;Galilei;1564-02-15
Isaac;Newton;1643-04-01
Albert;Einstein;1879-03-13
```
