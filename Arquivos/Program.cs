// See https://aka.ms/new-console-template for more information
#region AllLines
var fileA = File.ReadAllLines("names1.csv");
var fileB = File.ReadAllLines("names2.csv");

foreach (var n in fileA)
{
    Console.WriteLine($"ArquivoA: {n}");
}

foreach (var n in fileB)
{
    Console.WriteLine($"ArquivoB: {n}");
}

var merge = fileA.Union(fileB);

foreach (var n in merge)
{
    Console.WriteLine($"Merge: {n}");
}

var groupBy = from name in merge
              let n = name.Split(',')
              group name by n[0][0] into g
              orderby g.Key
              select g;

foreach (var g in groupBy)
{
    string fileName = @"testFile_" + g.Key + ".txt";

    Console.WriteLine(g.Key);

    File.WriteAllLines(fileName, g);
}
#endregion

#region LineByLine
List<string> fileC = new();
using (StreamReader sR = new StreamReader("names1.csv"))
{
    string linha = null;
    while ((linha = sR.ReadLine()) != null)
    {
        fileC.Add(linha);
    }
}

var fileD = File.ReadAllLines("names2.csv");
foreach (var n in fileA)
{
    Console.WriteLine($"ArquivoA: {n}");
}

foreach (var n in fileB)
{
    Console.WriteLine($"ArquivoB: {n}");
}

var mergeA = fileC.Union(fileD);

foreach (var n in merge)
{
    Console.WriteLine($"Merge: {n}");
}

var groupByA = from name in mergeA
              let n = name.Split(',')
              group name by n[0][0] into g
              orderby g.Key
              select g;

foreach (var g in groupByA)
{
    string fileName = @"testFile_" + g.Key + ".txt";

    Console.WriteLine(g.Key);

    using (StreamWriter sw = new StreamWriter(fileName))
    {
        foreach (var item in g)
        {
            sw.WriteLine(item);
            Console.WriteLine(item);
        }
    }
}
#endregion