namespace FileParser.Entities;
public interface IXmlSettings
{
    public string? XmlFolder { get; set; }
}
public class XmlSettings : IXmlSettings
{ 
    public string? XmlFolder { get; set; }
}
