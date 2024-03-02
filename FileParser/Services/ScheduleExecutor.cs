namespace FileParser.Services;

/// <summary>
/// Исполнитель расписания
/// </summary>
public class ScheduleExecutor : BackgroundService
{
    string _path = @"D:\Rab\FileParser\";
    readonly ILogger<ScheduleExecutor> _logger;
    public ScheduleExecutor(ILogger<ScheduleExecutor> logger)
    {
        _logger = logger;
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

    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        _logger.LogCritical($"Создан файл {e.FullPath}");
        var reader = new FileReaderService();
        _logger.LogError(reader.ReadFileContent(e.FullPath));
    }
}