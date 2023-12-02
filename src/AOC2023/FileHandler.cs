namespace AOC2023;
public interface IFileHandler
{
    Task<IEnumerable<string>> ReadLines(string path);
}

public class FileHandler : IFileHandler
{
    public async Task<IEnumerable<string>> ReadLines(string path)
    {
        using var reader = new StreamReader(path);
        var lines = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line != null)
            {
                lines.Add(line);
            }
        }
    }
}
