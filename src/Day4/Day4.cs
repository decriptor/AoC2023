using static Utils.Utils;

static class Day4
{
    // Attempts Part 1
    // 18653 <- Correct
    
    // Attempts Part 2
    // 68852 <- Wrong, too low
    // 73163 <- Wrong, too low
    // 

    public static void Main(string[] args)
    {
        //var data = GetInputs(4);
        var data = GetBasicInputs(4);

        var cards = ParseData(data);

        // Part 1
        int part1Points = cards.Sum(card => (int)Math.Pow(2, card.CommonNumbers.Count() - 1));
        Console.WriteLine($"Part 1 points: {part1Points}");
        
        // Part 2
        List<Card> totalCards = [];
        for (int i = 0; i < cards.Count; i++)
        {
            var matches = cards[i].CommonNumbers.Count();
            Console.WriteLine($"Card #: {cards[i].Number} -> Matches {matches}");
            if (matches <= 0) continue;
            
            totalCards.Add(cards[i]);
            
            for (int j = 1; j <= matches; j++)
            {
                totalCards.Add(cards[i + j]);
            }
            
            Console.WriteLine($"Total Card Count: {totalCards.Count}");
        }
        
        
        
        int part2Points = totalCards.Sum(card => (int)Math.Pow(2, card.CommonNumbers.Count() - 1));
        Console.WriteLine($"Part 2 points: {part2Points}");
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
            foreach (var num in winningNumbers.Where(n => n.Length > 0))
            {
                winNums.Add(int.Parse(num));
            }

            foreach (var num in playersNumbers.Where(n => n.Length > 0))
            {
                playerNums.Add(int.Parse(num));
            }

            cards.Add(new Card {
                Number = cardNumber,
                WinningNumbers = winNums,
                PlayersNumbers = playerNums
            });
        }

        return cards;
    }

    class Card
    {
        public string Number { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> PlayersNumbers { get; set; }

        public IEnumerable<int> CommonNumbers => WinningNumbers.Intersect(PlayersNumbers);

        public override string ToString()
        {
            return $"Card Number: {Number}";
        }
    }
}