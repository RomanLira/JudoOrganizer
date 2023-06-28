using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class MatchResult
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Round { get; set; }
    
    [JsonIgnore]
    public Match? Match { get; set; }
    public int MatchId { get; set; }
    
    [JsonIgnore]
    public Sportsman? Winner { get; set; }
    public int WinnerId { get; set; }
}