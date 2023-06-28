using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class Registration
{
    public int Id { get; set; }
    
    public string Date { get; set; }
    
    [JsonIgnore]
    public Tournament? Tournament { get; set; }
    public int TournamentId { get; set; }
    
    [JsonIgnore]
    public Sportsman? Sportsman { get; set; }
    public int SportsmanId { get; set; }

    [JsonIgnore]
    public SportCategory? SportCategory { get; set; }
    public int SportCategoryId { get; set; }
}