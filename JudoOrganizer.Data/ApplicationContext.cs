using JudoOrganizer.Data.Maps;
using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=judoDataBase;Username=postgres;Password=1");
    
    public DbSet<City> Cities { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchResult> MatchResults { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<SportCategory> SportCategories { get; set; }
    public DbSet<Sportsman> Sportsmen { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<TournamentResult> TournamentResults { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Weighing> Weighings { get; set; }
    public DbSet<Weight> Weights { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        new CityMap(model.Entity<City>());
        new ClubMap(model.Entity<Club>());
        new CoachMap(model.Entity<Coach>());
        new CountryMap(model.Entity<Country>());
        new MatchMap(model.Entity<Match>());
        new MatchResultMap(model.Entity<MatchResult>());
        new RegistrationMap(model.Entity<Registration>());
        new SportCategoryMap(model.Entity<SportCategory>());
        new SportsmanMap(model.Entity<Sportsman>());
        new TournamentMap(model.Entity<Tournament>());
        new TournamentResultMap(model.Entity<TournamentResult>());
        new UserMap(model.Entity<User>());
        new WeighingMap(model.Entity<Weighing>());
        new WeightMap(model.Entity<Weight>());
    }
}