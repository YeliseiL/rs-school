namespace FileParser.Services;

public interface INewFileWaiter
{
    public void Check();
}

public class NewFileWaiter : INewFileWaiter
{
    string _path = @"D:\";
    ILogger<NewFileWaiter> _logger;
    public NewFileWaiter (ILogger<NewFileWaiter> logger)
    {
        _logger = logger;
        Check();
    }

    public void Check() { 
    // Путь к файлу, который вы хотите проверить
    

        if (File.Exists(_path))
        {
            _logger.LogError("File exist");
        }
        else
        {
            _logger.LogError("File not exist");
        }
    }
}
