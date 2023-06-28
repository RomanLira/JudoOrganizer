using System.Text.Json.Serialization;
using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Data.Models;

public class SportCategory
{
    public int Id { get; set; }
    public string Sex { get; set; }
    public string DateOfBirth { get; set; }
    
    [JsonIgnore]
    public Tournament? Tournament { get; set; }
    public int TournamentId { get; set; }
    
    [JsonIgnore]
    public Weight? Weight { get; set; }
    public int WeightId { get; set; }
    
    public ICollection<Registration>? Registrations { get; set; }
    public ICollection<Weighing>? Weighing { get; set; }
    public ICollection<Match>? Matches { get; set; }
}