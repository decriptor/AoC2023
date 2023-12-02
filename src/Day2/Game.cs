namespace Day2;

record Game
{
    public required int Number { get; init; }
    public required List<Round> Rounds { get; init; }
}

record Round
{
    public required int Red { get; init; }
    public required int Green { get; init; }
    public required int Blue { get; init; }
}