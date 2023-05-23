using JudoOrganizer.Data.Maps;

namespace JudoOrganizer.Data.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Organizer { get; set; }
    public string Place { get; set; }
    public string Date { get; set; }

    public ICollection<SportCategory>? SportCategories { get; set; }
}