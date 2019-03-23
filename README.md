# CsvSharp
CSV Serializer &amp; Deserializer for C#

## Installation

**``Csv.Csharp`` is available on NuGet**

.NET Standard 2.0

[![NuGet](https://img.shields.io/nuget/v/Csv.Csharp.svg)](https://www.nuget.org/packages/Csv.Csharp/)

## Getting Started
A basic use of the project something like this...

``persons.csv`` without column names

```
Galileu;Galilei;1564-02-15
Isaac;Newton;1643-04-01
```

``Foo`` class

```csharp
using CsvSharp.Attributes;

public class Foo
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
    IEnumerable<Foo> collection = CsvConvert.Deserialize<Foo>(lines, CultureInfo.InvariantCulture);
}
```

``Result`` list
```
+-----------+----------+----------------------+
| Firstname | LastName |      BirthDate       |
+-----------+----------+----------------------+
| Galileu   | Galilei  | 1564-02-15 00:00:00  |
| Isaac     | Newton   | 1643-04-01 00:00:00  |
+-----------+----------+----------------------+
```

```csharp
using CsvSharp;
using System;
using System.Globalization;

void Main()
{
    IEnumerable<Foo> collection = ...
    
    //Get string text from collection
    string text = CsvConvert.Serialize(collection, CultureInfo.InvariantCulture);
    
    Console.WriteLine(text);
}
```

``Result`` text
```
Galileu;Galilei;1564-02-15
Isaac;Newton;1643-04-01
```
