namespace JudoOrganizer.Data.Models;

public class Registration
{
    public string Date { get; set; }
    
    public Tournament Tournament { get; set; }
    public int TournamentId { get; set; }
    
    public Sportsman Sportsman { get; set; }
    public int SportsmanId { get; set; }
    
    public User User { get; set; }
    public int UserId { get; set; }
    
    public SportCategory SportCategory { get; set; }
    public int SportCategoryId { get; set; }
}