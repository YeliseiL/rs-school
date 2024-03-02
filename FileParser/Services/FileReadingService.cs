namespace FileParser.Services;

public interface IFileReaderService
{
    string ReadFileContent(string filePath);
}
public class FileReaderService : IFileReaderService
{
    public string ReadFileContent(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return null;
        }
    }
}