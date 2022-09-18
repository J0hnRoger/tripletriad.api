namespace TripleTriad.Api.Models;

public class CardDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }
}