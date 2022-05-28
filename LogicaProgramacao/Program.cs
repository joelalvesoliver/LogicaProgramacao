// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;

Console.WriteLine("Hello, World!");



var A = new string[] { "as", "b" };

var x = true;
var y = true;
Console.WriteLine("XOR (Exclusive OR) operator exmample");
Console.WriteLine("*******************************");
//Console.WriteLine("Texto sem ascento - {0}", RemoverAcentuacao("texto com ascentuaÇão"));

Dictionary<char, int> _romanMap = new Dictionary<char, int>
{
   {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
};

Console.WriteLine(ConvertRomanToNumber("CMCM").ToString());        


string RemoverAcentuacao(string text)
{
    Console.WriteLine(text.Normalize(NormalizationForm.FormD)); 
    return new string(text
        .Normalize(NormalizationForm.FormD)
        .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
        .ToArray());
}



int ConvertRomanToNumber(string text)
{
    int totalValue = 0, prevValue = 0;
    foreach (var c in text)
    {
        if (!_romanMap.ContainsKey(c))
            return 0;
        var charValue = _romanMap[c];
        totalValue += charValue;
        if (prevValue != 0 && prevValue < charValue)
        {
            if (prevValue == 1 && (charValue == 5 || charValue == 10)
                || prevValue == 10 && (charValue == 50 || charValue == 100)
                || prevValue == 100 && (charValue == 500 || charValue == 1000))
                totalValue -= 2 * prevValue;
            else
                return 0;
        }
        prevValue = charValue;
    }
    return totalValue;
}
