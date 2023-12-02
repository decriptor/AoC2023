using Utils;
using static Utils.Utils;

// Get input data
var data = GetInputs(2);

var _redLimit = 12;
var _greenLimit = 13;
var _blueLimit = 14;

List<Game> ParseInputData(string[] inputs)
{
    var gameIndex = "Game".Length;

    var games = new List<Game>(inputs.Length);
    
    foreach (var input in inputs)
    {
        var colonIndex = input.IndexOf(':');
        var gameNumber = int.Parse(input.Substring(gameIndex, colonIndex));
        
        Console.WriteLine(gameNumber);
    }

    return games;
}

ParseInputData(data);

class Game
{
    public required int Number { get; set; }
    public required List<Round> Rounds { get; set; }
}

class Round
{
    public required int Red { get; set; }
    public required int Green { get; set; }
    public required int Blue { get; set; }
}