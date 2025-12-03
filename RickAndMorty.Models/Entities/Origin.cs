namespace RickAndMorty.Models.Entities;

public class Origin(
    string name, 
    string url
    )
{
    public string Name { get; private set; } = name;
    public string Url { get; private set; } = url;
}