using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Data.Models;

public class Draw
{
    public DrawType DrawType { get; set; }
    public string Date { get; set; }
    
    public Tournament Tournament { get; set; }
    public int TournamentId { get; set; }
    
    public Sportsman Sportsman { get; set; }
    public int SportsmanId { get; set; }
    
    public Match Match { get; set; }
    public int MatchId { get; set; }
}