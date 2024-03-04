namespace FileParser.Services;

public interface IFileReaderService
{
    Task ReadFileContent(string filePath);
}
public class FileReaderService : IFileReaderService
{
    readonly ILogger<FileReaderService> _logger;
    public FileReaderService(ILogger<FileReaderService> logger)
    {
        _logger = logger;
    }
    public async Task ReadFileContent(string filePath)
    {
        try
        {
            _logger.LogError($"filePath {filePath} поток {Thread.CurrentThread.ManagedThreadId} \n {await File.ReadAllTextAsync(filePath)}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка при чтении файла: {ex.Message}");
        }
    }
}