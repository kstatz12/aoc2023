namespace AOC2023
{
    public class JobConfig
    {
        private readonly Dictionary<int, IJob> _jobs = new Dictionary<int, IJob>();

        public JobConfig Register(int day, IJob job)
        {
            _jobs.Add(day, job);
            return this;
        }

        public async Task Run(int day, int part, string input)
        {
            if (_jobs.TryGetValue(day, out var job))
            {
                var result = await job.Run(input, part);
                Console.WriteLine($"Answer: {result}");
            }
            else
            {
                Console.WriteLine($"Day {day} not found");
            }
        }
    }

    public interface IJob
    {
        Task<string> Run(string input, int part);
    }
}
