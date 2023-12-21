namespace GrooveHub.Models;

public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public List<Music> Musics { get; set; }
}