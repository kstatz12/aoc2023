namespace AOC2023.Jobs;

public class Day1 : IJob
{
    private readonly IFileHandler fileHandler;
    public Day1(IFileHandler fileHandler)
    {
        this.fileHandler = fileHandler;
    }

    public async Task<string> Run(string input, int part)
    {
        var lines = await this.fileHandler.ReadLines(input);
        return part switch
        {
            1 => PartOne(lines).ToString(),
            2 => PartTwo(lines).ToString(),
            _ => throw new ArgumentException("Invalid part", nameof(part))
        };
    }

    private static int PartTwo(IEnumerable<string> lines)
    {
        return lines.Select(x => Replace(x))
            .Select(x => Parse(x))
            .Sum();
    }

    private static int PartOne(IEnumerable<string> lines)
    {
        return lines.Select(x => Parse(x))
            .Sum();
    }

    private static int Parse(string line)
    {
        var d = line.Where(x => Char.IsDigit(x));
        return int.Parse($"{d.First()}{d.Last()}");
    }

    private static string Replace(string s) =>
        s.Replace("one", "one1one")
        .Replace("two", "two2two")
        .Replace("three", "three3three")
        .Replace("four", "four4four")
        .Replace("five", "five5five")
        .Replace("six", "six6six")
        .Replace("seven", "seven7seven")
        .Replace("eight", "eight8eight")
        .Replace("nine", "nine9nine");
}
