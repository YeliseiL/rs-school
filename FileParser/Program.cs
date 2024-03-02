using FileParser.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .AddSimpleConsole(o =>
    {
        o.TimestampFormat = "HH:mm:ss ";
        o.UseUtcTimestamp = true;
    });

builder.Services.AddHostedService<ScheduleExecutor>();

var app = builder.Build();

app.Run();