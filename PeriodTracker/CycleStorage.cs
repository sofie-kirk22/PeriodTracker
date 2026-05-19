using System.Text.Json;

public class CycleStorage
{
    private readonly string _filePath;

    public CycleStorage(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveCycles(List<Cycle> cycles)
    {
        var json = JsonSerializer.Serialize(cycles, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }

    public List<Cycle> LoadCycles()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Cycle>();
        }

        var json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Cycle>>(json) ?? new List<Cycle>();
    }
}