namespace FileParser.Services;

/// <summary>
/// Исполнитель расписания
/// </summary>
public class ScheduleExecutor : BackgroundService
{
    readonly TimeSpan _timerTime;
    readonly INewFileWaiter _newFileWaiter;
    public ScheduleExecutor(INewFileWaiter newFileWaiter)
    {
        _timerTime = TimeSpan.FromSeconds(1);
        _newFileWaiter = newFileWaiter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(_timerTime);
            _newFileWaiter.CheckNewXml();
        }
    }
}
