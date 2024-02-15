using System.ServiceProcess;
using System.Timers;

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
public partial class FileReadingService : ServiceBase
{
    private readonly IFileReaderService _fileReaderService;
    private readonly string _filePath = @"C:\путь\к\вашему\файлу.txt"; // Укажите свой путь к файлу

    public FileReadingService(IFileReaderService fileReaderService)
    {
        _fileReaderService = fileReaderService;
    }

    private void ReadFile(object sender, ElapsedEventArgs e)
    {
        string fileContent = _fileReaderService.ReadFileContent(_filePath);
        if (fileContent != null)
        {
            Console.WriteLine($"Содержимое файла {_filePath}:\n{fileContent}");
        }
    }
}