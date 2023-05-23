namespace JudoOrganizer.Data.Models;

public class TournamentResult
{
    public int Id { get; set; }
    public string Date { get; set; }
    
    public Tournament Tournament { get; set; }
    public int TournamentId { get; set; }

    public ICollection<MatchResult>? MatchResults { get; set; }
}