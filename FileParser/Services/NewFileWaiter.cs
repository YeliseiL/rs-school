namespace FileParser.Services;

public interface INewFileWaiter
{
    public void CheckNewXml();
}

public class NewFileWaiter : INewFileWaiter
{
    readonly string _path;
    readonly IFileReaderService _fileReaderService;
    public NewFileWaiter (IFileReaderService fileReaderService, string? path)
    {
        if (string.IsNullOrEmpty(path))
            throw new Exception("path");

        _path = path;

        _fileReaderService = fileReaderService;

        CheckNewXml();
    }

    public void CheckNewXml() 
    {
        // Путь к файлу, который вы хотите проверить
        using (var watcher = new FileSystemWatcher(_path))
        {
            watcher.Filter = "*.xml";
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = true;

            //Console.WriteLine($"Отслеживаем директорию: {_path}");
            //Console.WriteLine("Нажмите Enter для завершения...");
            //Console.ReadLine();
        }
    }
    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        _fileReaderService.ReadFileContent(e.FullPath);
    }
}