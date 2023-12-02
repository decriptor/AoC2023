namespace Day2;

using static Utils.Utils;

static class Day2
{
    public static void Main(string[] args)
    {
        var data = GetInputs(2);
        var games = ParseInputData(data);

        var possibleGames = new List<int>();
        var powerGames = new List<int>();
        foreach (var game in games)
        {
            //PrintGame(game);
            if (IsGamePossible(game))
                possibleGames.Add(game.Number);

            powerGames.Add(CalculateGamePower(game));
        }

        Console.WriteLine($"Sum of possible Games {possibleGames.Sum()}");
        Console.WriteLine($"Sum of power Games {powerGames.Sum()}");
    }

    static bool IsGamePossible(Game game)
    {
        var redLimit = 12;
        var greenLimit = 13;
        var blueLimit = 14;

        foreach (var round in game.Rounds)
        {
            if (round.Red > redLimit)
                return false;
            if (round.Green > greenLimit)
                return false;
            if (round.Blue > blueLimit)
                return false;
        }

        return true;
    }

    static int CalculateGamePower(Game game)
    {
        var red = 0;
        var green = 0;
        var blue = 0;

        foreach (var round in game.Rounds)
        {
            if (round.Red > red)
                red = round.Red;
            if (round.Green > green)
                green = round.Green;
            if (round.Blue > blue)
                blue = round.Blue;
        }

        return red * green * blue;
    }

    static List<Game> ParseInputData(IReadOnlyCollection<string> games)
    {
        var games1 = new List<Game>(games.Count);

        var gameIndex = "Game ".Length;

        foreach (var game in games)
        {
            var colonIndex = game.IndexOf(':');
            var gameNumber = int.Parse(game.Substring(gameIndex, colonIndex - gameIndex));

            var roundsSplit = game[(colonIndex + 1)..].Split(';');
            var rounds = ParseGameRounds(roundsSplit);

            games1.Add(new Game { Number = gameNumber, Rounds = rounds });
        }

        return games1;
    }

    static List<Round> ParseGameRounds(IReadOnlyCollection<string> rounds)
    {
        var gameRounds = new List<Round>();
        foreach (var round in rounds)
        {
            var colors = round.Split(',');

            var red = 0;
            var green = 0;
            var blue = 0;

            foreach (var color in colors)
            {
                var parts = color.Trim().Split(' ');
                var count = int.Parse(parts[0]);

                switch (parts[1])
                {
                    case "red":
                        red = count;
                        break;
                    case "green":
                        green = count;
                        break;
                    case "blue":
                        blue = count;
                        break;
                }
            }

            gameRounds.Add(new Round { Red = red, Green = green, Blue = blue });
        }

        return gameRounds;
    }

    static void PrintGame(Game game)
    {
        Console.WriteLine($"Game {game.Number}. Round Count: {game.Rounds.Count}");
        foreach (var round in game.Rounds)
        {
            Console.WriteLine($"\tRed: {round.Red}, Green: {round.Green}, Blue: {round.Blue}");
        }
    }
}