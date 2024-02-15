using FileParser.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .AddSimpleConsole(o =>
    {
        o.TimestampFormat = "HH:mm:ss ";
        o.UseUtcTimestamp = true;
    });

builder.Services.AddSingleton<INewFileWaiter, NewFileWaiter>();
builder.Services.AddHostedService<ScheduleExecutor>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
