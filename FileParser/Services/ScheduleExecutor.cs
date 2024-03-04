using FileParser.Entities;

namespace FileParser.Services;

/// <summary>
/// Исполнитель расписания
/// </summary>
public class ScheduleExecutor : BackgroundService
{
    readonly string _path;
    readonly ILogger<ScheduleExecutor> _logger;
    readonly IFileReaderService _fileReaderService;
    public ScheduleExecutor(ILogger<ScheduleExecutor> logger, IFileReaderService fileReaderService, IXmlSettings settings)
    {
        _logger = logger;
        _fileReaderService = fileReaderService;
        _path = settings!.XmlFolder!;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        CheckNewXml();
    }
    public void CheckNewXml()
    {
        // Путь к файлу, который вы хотите проверить
        var watcher = new FileSystemWatcher(_path);
        
        watcher.Filter = "*.*";
        watcher.Created += OnFileCreated;
        watcher.EnableRaisingEvents = true;

        _logger.LogInformation($"Отслеживаем директорию: {_path}");
    }

    private async void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        _logger.LogInformation($"Создан файл {e.FullPath}");

        Thread thread = new Thread( async ()=>
            Task.Run(async () => _fileReaderService.ReadFileContent(e.FullPath))
        );
        thread.Start();

        _logger.LogInformation($"Обрабатывается {e.FullPath} поток {Thread.CurrentThread.ManagedThreadId}");
    }
}