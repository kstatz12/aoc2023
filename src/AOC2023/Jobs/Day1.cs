namespace AOC2023.Jobs;
using System.Text.RegularExpressions;

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
        return lines.Select(x=> PartTwoParse(x))
            .Select(x => int.Parse($"{x.Item1}{x.Item2}"))
            .Sum();
    }

    private static int PartOne(IEnumerable<string> lines)
    {
        return lines.Select(x => PartOneParse(x))
            .Select(x => int.Parse($"{x.Item1}{x.Item2}"))
            .Sum();
    }

    private static (int, int) PartTwoParse(string line)
    {
        return (Seek2(line, RegexOptions.None), Seek2(line, RegexOptions.RightToLeft));
    }

    private static (int, int) PartOneParse(string line)
    {
        return (Seek(line), Seek(Reverse(line)));
    }

    private static string Reverse(string input)
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    private static int Seek2(string input, RegexOptions options)
    {
        var match = Match(input, options);
        if(int.TryParse(match, out var result))
        {
            return result;
        }
        throw new ArgumentException($"Input {input} is not a number", nameof(input));
    }

    private static int Seek(string input)
    {
        foreach(var c in input)
        {
            var (success, result) = CharToInt(c);
            if(success)
            {
                return result;
            }
        }
        throw new ArgumentException($"Input is not a number {input}");
    }

    private static string BuildRegex() => @"\b(?:[0-9]+|one|two|three|four|five|six|seven|eight|nine)\b";

    private static string Match(string input, RegexOptions options = RegexOptions.RightToLeft)
    {
        var pattern = BuildRegex();
        var matches = Regex.Matches(input, pattern, options);
        return matches.FirstOrDefault()?.Value ?? string.Empty;
    }

    private static (bool, int) CharToInt(char c) => c switch
    {
        '0' => (true, 0),
        '1' => (true, 1),
        '2' => (true, 2),
        '3' => (true, 3),
        '4' => (true, 4),
        '5' => (true, 5),
        '6' => (true, 6),
        '7' => (true, 7),
        '8' => (true, 8),
        '9' => (true, 9),
        _ => (false, -1)
    };
}

