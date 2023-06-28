using System.Text.Json.Serialization;

namespace JudoOrganizer.Data.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public Country? Country { get; set; }
    public int CountryId { get; set; }

    public ICollection<Club>? Clubs { get; set; }
}