using FileParser.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Logging
    .AddSimpleConsole(o =>
    {
        o.TimestampFormat = "HH:mm:ss ";
        o.UseUtcTimestamp = true;
    });

builder.Services.AddHostedService<ScheduleExecutor>();

builder.Services.AddTransient<IFileReaderService, FileReaderService>();

builder.Services.AddSettings(configuration);

var app = builder.Build();

app.Run();