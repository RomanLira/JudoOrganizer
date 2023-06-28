using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class Match
{
    public int Id { get; set; }
    public int Number { get; set; }
    public List<int> Rivals { get; set; }
    
    [JsonIgnore]
    public Tournament? Tournament { get; set; }
    public int TournamentId { get; set; }
    
    [JsonIgnore]
    public SportCategory? SportCategory { get; set; }
    public int SportCategoryId { get; set; }
}