using System.Text.Json.Serialization;
using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Data.Models;

public class Sportsman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string DateOfBirth { get; set; }
    public string Sex { get; set; }

    [JsonIgnore]
    public Club? Club { get; set; }
    public int ClubId { get; set; }
    
    [JsonIgnore]
    public Coach? Coach { get; set; }
    public int CoachId { get; set; }
    
    public ICollection<MatchResult>? MatchResults { get; set; }
    public ICollection<Registration>? Registrations { get; set; }
    public ICollection<Weighing>? Weighing { get; set; }
}