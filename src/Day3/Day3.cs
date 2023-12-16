namespace Day3;

using static Utils.Utils;

static class Day3
{
    // Attempts Part 1
    // 539219 <- too low
    // 318828 <- too low
    // 540983 <- Wrong
    // 540212 <- Correct

    // Attempts Part 2
    // 87605697 <- Correct

    public static void Main(string[] args)
    {
        var data = GetInputs(3);

        var results = FindNumbersAndGears(data);

        int sum = results.Numbers.Sum(int.Parse);
        Console.WriteLine($"Sum: {sum}");

        int ratio = 0;
        foreach (var gear in results.Gears.Where(x => x.Value.Count == 2))
        {
            ratio += gear.Value.Aggregate(1, (current, gearNumber) => current * int.Parse(gearNumber));
        }

        Console.WriteLine($"Gear ratio: {ratio}");
    }

    static (List<string> Numbers, Dictionary<(int, int), List<string>> Gears) FindNumbersAndGears(
        IReadOnlyList<string> data)
    {
        List<string> adjacentNumbers = [];
        var gears = new Dictionary<(int, int), List<string>>();

        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var number = string.Empty;
                int start = j;
                if (char.IsNumber(data[i][j]))
                {
                    while (j < data[i].Length && char.IsNumber(data[i][j]))
                        number += data[i][j++];

                    //Console.Write($"Number: {number} -> ");
                    var symbol = CheckForSymbol(data, i, start, number.Length);
                    if (symbol.IsValidSymbol)
                    {
                        adjacentNumbers.Add(number);
                        if (symbol.IsGear)
                        {
                            if (!gears.ContainsKey((symbol.X, symbol.Y)))
                            {
                                gears.Add((symbol.X, symbol.Y), []);
                            }

                            gears[(symbol.X, symbol.Y)].Add(number);
                        }

                        //Console.WriteLine($"{symbol.SymbolChar}");
                    }
                    else
                    {
                        //Console.WriteLine();
                    }
                }
            }
        }

        return (adjacentNumbers, gears);
    }

    static Symbol CheckForSymbol(IReadOnlyList<string> data, int x, int y, int numberLength)
    {
        int startX = (x <= 0) ? 0 : x - 1;
        int startY = (y <= 0) ? 0 : y - 1;
        int endX = x + 1;
        int endY = y + numberLength;

        if (endX >= data.Count)
            endX = data.Count - 1;
        if (endY >= data[x].Length)
            endY = data[x].Length - 1;

        Symbol symbol = null;
        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j <= endY; j++)
            {
                if (data[i][j] == '.') continue;
                if (char.IsNumber(data[i][j])) continue;

                symbol = new Symbol(i, j, data[i][j]);
            }
        }

        return symbol ?? new Symbol(x, y, '.');
    }

    class Symbol(int x, int y, char symbolChar)
    {
        public int X => x;
        public int Y => y;
        public char SymbolChar => symbolChar;
        public bool IsValidSymbol => symbolChar != '.';
        public bool IsGear => symbolChar == '*';
    }
}