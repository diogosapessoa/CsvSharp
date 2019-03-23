# CsvNet
CSV Serializer &amp; Deserializer for C#

## Getting Started
A basic use of the project something like this...

``persons.csv`` without column names

```
Galileu;Galilei;1564-02-15
Isaac;Newton;1643-04-01
```

``Foo`` class

```csharp
using CsvNet.Attributes;

public class Foo
{
	public string FirstName { get; set; }

	public string LastName { get; set; }
	
	[CsvDateTimeFormat("yyyy-MM-dd")]
	public DateTime BirthDate { get; set; }
}
```

```csharp
using CsvNet;
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
| Galileu   | Galilei  | 15/02/1564 00:00:00  |
| Isaac     | Newton   | 01/04/1643 00:00:00  |
+-----------+----------+----------------------+
```

```csharp
using CsvNet;
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
