namespace Utils;

public static class Extensions
{
    public static IEnumerable<int> IndexOfAll(this string str, string substr)
    {
        var indexes = new List<int>();
        int index = 0;

        while ((index = str.IndexOf(substr, index, StringComparison.Ordinal)) != -1)
        {
            indexes.Add(index++);
        }

        return indexes;
    }
}