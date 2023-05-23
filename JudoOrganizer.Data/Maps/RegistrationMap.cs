using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class RegistrationMap
{
    public RegistrationMap(EntityTypeBuilder<Registration> builder)
    {
        builder.HasKey(registration => new {registration.SportsmanId, registration.TournamentId, registration.SportCategoryId, registration.UserId});
        
        builder
            .HasOne(registration => registration.Tournament)
            .WithOne()
            .HasForeignKey<Registration>(registration => registration.TournamentId);

        builder
            .HasOne(registration => registration.Sportsman)
            .WithOne()
            .HasForeignKey<Registration>(registration => registration.SportsmanId);

        builder
            .HasOne(registration => registration.User)
            .WithOne()
            .HasForeignKey<Registration>(registration => registration.UserId);
        
        builder
            .HasOne(registration => registration.SportCategory)
            .WithOne()
            .HasForeignKey<Registration>(registration => registration.SportCategoryId);
    }
}