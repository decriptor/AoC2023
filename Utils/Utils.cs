namespace Utils;

public static class Utils
{
    public static string[] GetInputs(int day)
    {
        var path = Path.Combine("d:", "code", "AdventOfcode", "Inputs", $"Day{day}Input.txt");
        if (!Path.Exists(path))
            throw new FileNotFoundException(path);
        
        return File.ReadAllLines(path);
    }
}