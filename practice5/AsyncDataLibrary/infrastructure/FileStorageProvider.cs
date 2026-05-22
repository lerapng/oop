namespace AsyncDataLibrary.Infrastructure;

public class FileStorageProvider
{
    private readonly string _basePath;

    public FileStorageProvider(string basePath = "data")
    {
        _basePath = basePath;
        Directory.CreateDirectory(_basePath);
    }

    public string GetFilePath(string fileName) =>
        Path.Combine(_basePath, fileName);

    public async Task<string> ReadAsync(string fileName)
    {
        string path = GetFilePath(fileName);
        if (!File.Exists(path)) return "[]";
        return await File.ReadAllTextAsync(path);
    }

    public async Task WriteAsync(string fileName, string content) =>
        await File.WriteAllTextAsync(GetFilePath(fileName), content);

    public string Read(string fileName)
    {
        string path = GetFilePath(fileName);
        if (!File.Exists(path)) return "[]";
        return File.ReadAllText(path);
    }

    public void Write(string fileName, string content) =>
        File.WriteAllText(GetFilePath(fileName), content);
}