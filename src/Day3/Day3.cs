namespace Day3;

using static Utils.Utils;

static class Day3
{
    public static void Main(string[] args)
    {
        var data = GetInputs(3);

        ParseData(data);
    }

    private static void ParseData(IReadOnlyList<string> data)
    {
        var adjacents = new Dictionary<string, int>();
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var target = data[i][j];
                if (target != '.')
                {
                    var number = target.ToString();
                    if (char.IsNumber(target))
                    {
                        while (j < data[i].Length && char.IsNumber(data[i][j + 1]))
                        {
                            target += data[i][++j];
                        }
                    }

                    Console.WriteLine($"Found: {target}. Index [{i}][{j}]");
                    // target [i][j]
                }
            }
        }
    }
}