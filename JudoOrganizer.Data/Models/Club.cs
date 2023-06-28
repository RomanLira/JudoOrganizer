using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    [JsonIgnore]
    public City? City { get; set; }
    public int CityId { get; set; }
    
    public ICollection<Coach>? Coaches { get; set; }
    public ICollection<Sportsman>? Sportsmen { get; set; }
}