using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Data.Models;

public class SportCategory
{
    public int Id { get; set; }
    public Sex Sex { get; set; }
    public string DateOfBirth { get; set; }
    
    public Tournament Tournament { get; set; }
    public int TournamentId { get; set; }
    
    public Weight Weight { get; set; }
    public int WeightId { get; set; }
}