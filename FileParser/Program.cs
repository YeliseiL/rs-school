using FileParser.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .AddSimpleConsole(o =>
    {
        o.TimestampFormat = "HH:mm:ss ";
        o.UseUtcTimestamp = true;
    });

builder.Services.AddHostedService<ScheduleExecutor>();

builder.Services.AddTransient<IFileReaderService, FileReaderService>();

var app = builder.Build();

app.Run();