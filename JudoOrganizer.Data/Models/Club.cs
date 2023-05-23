namespace JudoOrganizer.Data.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }

    public City City { get; set; }
    public int CityId { get; set; }
    
    public ICollection<Coach>? Coaches { get; set; }
    public ICollection<Sportsman>? Sportsmen { get; set; }
}