using System.Collections;
using JudoOrganizer.Data.Enums;
using JudoOrganizer.Data.Maps;

namespace JudoOrganizer.Data.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Organizer { get; set; }
    public string Place { get; set; }
    public string Date { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }

    public ICollection<SportCategory>? SportCategories { get; set; }
    public ICollection<Registration>? Registrations { get; set; }
    public ICollection<Weighing>? Weighing { get; set; }
    public ICollection<Match>? Matches { get; set; }
}