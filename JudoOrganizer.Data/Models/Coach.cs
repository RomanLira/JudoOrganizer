using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class Coach
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Phone { get; set; }
    
    [JsonIgnore]
    public Club? Club { get; set; }
    public int ClubId { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
    public int UserId { get; set; }
    
    public ICollection<Sportsman>? Sportsmen { get; set; }
}