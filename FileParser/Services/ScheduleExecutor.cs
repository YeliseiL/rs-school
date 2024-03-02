namespace FileParser.Services;

/// <summary>
/// Исполнитель расписания
/// </summary>
public class ScheduleExecutor : BackgroundService
{
    string _path;

    public ScheduleExecutor()
    {

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _path = @"D:\";
        CheckNewXml();
    }
    public void CheckNewXml()
    {
        // Путь к файлу, который вы хотите проверить
        using (var watcher = new FileSystemWatcher(_path))
        {
            watcher.Filter = "*.*";
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Отслеживаем директорию: {_path}");
            Console.WriteLine("Нажмите Enter для завершения...");
            Console.ReadLine();
        }
    }

    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {

        Console.WriteLine($"Создан файл {e.FullPath}");
    }
}