namespace TripleTriad.Api.Models;

public class PlayerDto
{
    public string Name { get; set; }
    public List<CardDto> Deck { get; set; }
}