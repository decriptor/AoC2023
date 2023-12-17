using static Utils.Utils;

static class Day5
{
    // Attempts Part 1
    // 

    // Attempts Part 2
    // 

    public static void Main(string[] args)
    {
        //var data = GetInputs(5);
        var data = GetBasicInputs(5);

        var almanac = ParseData(data);
        
        almanac.Print();
    }

    static Almanac ParseData(string[] data)
    {
        var almanac = new Almanac();
        foreach (var line in data)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            if (line.StartsWith("seeds:"))
            {
                var seedLine = line[(line.IndexOf(':') + 1)..].Trim();
                almanac.Seeds.AddRange(GetSeedList(seedLine));
            }

            if (line.StartsWith("seed-to-soil"))
            {
                // build seed to soil map
            }
        }

        return almanac;
    }

    static IEnumerable<int> GetSeedList(string seedsString)
    {
        return seedsString.Split((' ')).Select(int.Parse);
    }

    class Almanac
    {
        public List<int> Seeds { get; set; } = [];
        public Dictionary<int, int> SeedToSoil { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> SoilToFertilizer { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> FertilizerToWater { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> WaterToLight { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> LightToTemperature { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> TemperatureToHumidity { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> HumidityToLocation { get; set; } = new Dictionary<int, int>();

        public void Print()
        {
            Console.WriteLine($"Seeds:");
            Console.Write("\t");
            foreach (var seed in Seeds)
            {
                Console.Write($"{seed},");
            }
        }
    }
}