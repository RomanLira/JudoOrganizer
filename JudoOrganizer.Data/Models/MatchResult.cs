namespace JudoOrganizer.Data.Models;

public class MatchResult
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Round { get; set; }

    public TournamentResult TournamentResult { get; set; }
    public int TournamentResultId { get; set; }
    
    public Match Match { get; set; }
    public int MatchId { get; set; }
    
    public Sportsman Winner { get; set; }
    public int WinnerId { get; set; }
}