// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<string> fileA= new();//File.ReadAllLines("names1.csv");
string[] teste = { };
using (StreamReader sR = new StreamReader("names1.csv")) 
{
    string linha = null;
    while ((linha = sR.ReadLine()) != null)
    {
        var a = teste.Append(linha);
        fileA.Add(linha);
    }
}

var fileB = File.ReadAllLines("names2.csv");
foreach(var n in fileA)
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
    string fileName = @"testFile_" + g.Key+".txt";

    Console.WriteLine(g.Key);

    File.WriteAllLines(fileName, g);
    //using (StreamWriter sw = new StreamWriter(fileName))
    //{
    //    foreach (var item in g)
    //    {
    //        sw.WriteLine(item);
    //        Console.WriteLine(item);
    //    }
    //}
}