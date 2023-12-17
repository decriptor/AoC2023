using static Utils.Utils;

static class Day4
{
    // Attempts Part 1
    // 18653 <- Correct

    // Attempts Part 2
    // 68852 <- Wrong, too low
    // 73163 <- Wrong, too low
    // 5921508 <- Correct

    public static void Main(string[] args)
    {
        var data = GetInputs(4);
        //var data = GetBasicInputs(4);

        var cards = ParseData(data);

        // Part 1
        int part1Points = cards.Sum(card => (int)Math.Pow(2, card.CommonNumbers.Count() - 1));
        Console.WriteLine($"Part 1 points: {part1Points}");

        // Part 2
        var totalCards = cards.OrderBy(x => x.Number).ToList();
        for (int i = 1; i <= cards.Count; i++)
        {
            var copies = ProcessCard(totalCards, i);
            totalCards.AddRange(copies);
        }

        Console.WriteLine($"Total cards: {totalCards.Count}");
    }

    static IEnumerable<Card> ProcessCard(IReadOnlyCollection<Card> cards, int cardGame)
    {
        List<Card> additionalCards = [];

        int count = cards.First(x => x.Number == cardGame).CommonNumbers.Count();

        foreach (var card in cards.Where(x => x.Number == cardGame))
        {
            var startingCard = cardGame + 1;
            for (int i = 0; i < count; i++)
            {
                additionalCards.Add(cards.First(x => x.Number == startingCard + i));
            }
        }

        return additionalCards;
    }

    static List<Card> ParseData(IEnumerable<string> data)
    {
        List<Card> cards = [];

        foreach (var line in data)
        {
            var colon = line.IndexOf(':') + 1;
            var pipe = line.IndexOf('|') + 1;
            var cardNumber = line.Substring(4, colon - 5).Trim();

            var winningNumbers = line.Substring(colon, pipe - colon - 1).Trim().Split(' ');
            var playersNumbers = line[pipe..].Trim().Split(' ');

            List<int> winNums = [];
            List<int> playerNums = [];
            winNums.AddRange(winningNumbers.Where(n => n.Length > 0).Select(int.Parse));

            playerNums.AddRange(playersNumbers.Where(n => n.Length > 0).Select(int.Parse));

            cards.Add(new Card
            {
                Number = int.Parse(cardNumber),
                WinningNumbers = winNums,
                PlayersNumbers = playerNums
            });
        }

        return cards;
    }

    class Card
    {
        public int Number { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> PlayersNumbers { get; set; }

        public IEnumerable<int> CommonNumbers => WinningNumbers.Intersect(PlayersNumbers);

        public override string ToString()
        {
            return $"Card Number: {Number}";
        }
    }
}