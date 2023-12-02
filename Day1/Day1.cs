using Utils;
using static Utils.Utils;

// Get input data
var inputs = GetInputs(1);

// all written values
var numStrings = new Dictionary<string, int>()
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 }
};

SortedList<int, int> ParseDigits(string data)
{
    var numbers = new SortedList<int, int>();

    // Get all numerical values
    for (int i = 0; i < data.Length; i++)
    {
        if (char.IsNumber(data[i]))
        {
            numbers.Add(i, (int)char.GetNumericValue(data[i]));
        }
    }

    return numbers;
}

SortedList<int, int> ParseAllNumbers(string data, SortedList<int, int> digits)
{
    // Get Digits first
    var numbers = new SortedList<int, int>(digits);
    
    // Find all written numbers
    foreach (var numString in numStrings)
    {
        foreach(var result in data.IndexOfAll(numString.Key))
        {
            numbers.Add(result, numString.Value);
        }
    }

    return numbers;
}

(List<int> Digits, List<int> AllNumbers) ParseNumbers(IEnumerable<string> data)
{
    var digits = new List<int>();
    var digitsAndStrings = new List<int>();

    foreach (var line in data)
    {
        var sortedDigit = ParseDigits(line);
        digits.Add(GetInt(sortedDigit));

        var sortedDigits = ParseAllNumbers(line, sortedDigit);
        digitsAndStrings.Add(GetInt(sortedDigits));
    }
    
    return (digits, digitsAndStrings);
}

int GetInt(SortedList<int, int> ints)
{
    var first = ints.First().Value * 10;
    var last = ints.Last().Value;

    return first + last;
}

var ints = ParseNumbers(inputs);

Console.WriteLine($"Part 1: {ints.Digits.Sum()}");
Console.WriteLine($"Part 2: {ints.AllNumbers.Sum()}");
