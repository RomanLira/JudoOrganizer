namespace JudoOrganizer.Data.Models;

public class Match
{
    public int Id { get; set; }
    
    public Sportsman Sportsman { get; set; }
    public int SportsmanId { get; set; }
}