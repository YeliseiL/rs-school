using FileParser.Entities;

namespace FileParser.Services;

public static class SettingsExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new XmlSettings();

        configuration.GetSection("XmlSettings").Bind(settings);

        if (string.IsNullOrEmpty(settings.XmlFolder))
            throw new Exception("Xml folder is empty");

        services.AddSingleton<IXmlSettings, XmlSettings>(s => settings);

        return services;
    }
}
