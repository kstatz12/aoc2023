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
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input is null or empty", nameof(input));
        }

        var lines = await this.fileHandler.ReadLines(input);
        return part switch
        {
            1 => PartOne(lines).ToString(),
            2 => "Not implemented",
            _ => throw new ArgumentException("Invalid part", nameof(part))
        };
    }

    private static int PartOne(IEnumerable<string> lines)
    {
        return lines.Select(x => PartOneParse(x))
            .Select(x => x.Item1 + x.Item2)
            .Sum();
    }

    private static (int, int) PartOneParse(string line)
    {
        return (Forwards(line), Backwards(line));
    }

    private static int Forwards(string input)
    {
        foreach (var s in input)
        {
            var (success, value) = CharToInt(s);
            if (success)
            {
                return value;
            }
        }
        throw new ArgumentException("Input is not a number", nameof(input));
    }

    private static int Backwards(string input)
    {
        foreach (var s in input.Reverse())
        {
            var (success, value) = CharToInt(input[i]);
            if (success)
            {
                return value;
            }
        }
        throw new ArgumentException("Input is not a number", nameof(input));
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

