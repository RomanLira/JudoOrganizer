namespace JudoOrganizer.Data.Models;

public class Coach
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Phone { get; set; }
    
    public Club Club { get; set; }
    public int ClubId { get; set; }
    
    public ICollection<Sportsman>? Sportsmen { get; set; }
}