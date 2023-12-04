using AOC2023.Jobs;

namespace AOC2023.UnitTests;

public class DayTest
{
    [Fact]
    public async Task Day1Part1()
    {
        var day1 = new Day1(new Day1FakeFileHandler());
        var result = new TestExecutor(day1).Execute(1);
        Assert.Equal("142", await result);
    }

    [Fact]
    public async Task Day1Part2()
    {
        var day1 = new Day1(new Day1FakeFileHandler2());
        var result = new TestExecutor(day1).Execute(2);
        Assert.Equal("281", await result);
    }

    private class TestExecutor
    {
        private readonly IJob Job;
        public TestExecutor(IJob job)
        {
            Job = job;
        }

        public async Task<string> Execute(int part)
        {
            return await Job.Run(string.Empty, part);
        }
    }

    private class Day1FakeFileHandler2 : IFileHandler
    {
        public Task<IEnumerable<string>> ReadLines(string path)
        {
            return Task.FromResult(new List<string>
            {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"
            }.AsEnumerable());
            throw new NotImplementedException();
        }
    }

    private class Day1FakeFileHandler : IFileHandler
    {
        public Task<IEnumerable<string>> ReadLines(string path)
        {
            return Task.FromResult(new List<string>
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            }.AsEnumerable());
        }
    }
}
