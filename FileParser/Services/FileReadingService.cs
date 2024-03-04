namespace FileParser.Services;

public interface IFileReaderService
{
    Task<string> ReadFileContent(string filePath);
}
public class FileReaderService : IFileReaderService
{
    public async Task<string> ReadFileContent(string filePath)
    {
        try
        {
            return await File.ReadAllTextAsync(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return null;
        }
    }
}