// See https://aka.ms/new-console-template for more information
using AOC2023;
using AOC2023.Jobs;

internal class Program
{
    private static async Task Main(string[] args)
    {
        JobConfig jc = new JobConfig();
        jc.Register(1, new Day1(new FileHandler()));
        var (day, part, input) = Parse(args);
        await jc.Run(day, part, input);
    }


    private static (int, int, string) Parse(string[] args) => (int.Parse(args[0]), int.Parse(args[1]), args[2]);
}
