namespace Utils;

public static class Utils
{
    public static string[] GetInputs(int day)
    {
        var path = Path.Combine("..", "..", "..", "..", "..", "Inputs", $"Day{day}Input.txt");
        if (!Path.Exists(path))
            throw new FileNotFoundException(path);
        
        return File.ReadAllLines(path);
    }

    public static string[] GetBasicInputs(int day)
    {
        var path = Path.Combine("..", "..", "..", "..", "..", "Inputs", $"Day{day}Input_Basic.txt");
        if (!Path.Exists(path))
            throw new FileNotFoundException(path);
        
        return File.ReadAllLines(path);
    }
}