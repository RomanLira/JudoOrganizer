using JudoOrganizer.Data.Maps;

namespace JudoOrganizer.Data.Models;

public class Weight
{
    public int Id { get; set; }
    public int WeightValue { get; set; }
    
    public ICollection<SportCategory>? SportCategories { get; set; }
}