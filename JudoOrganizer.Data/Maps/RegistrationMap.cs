using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class RegistrationMap
{
    public RegistrationMap(EntityTypeBuilder<Registration> builder)
    {
        builder.HasKey(registration => registration.Id);
        
        builder
            .HasOne(registration => registration.Tournament)
            .WithMany(tournament => tournament.Registrations)
            .HasForeignKey(registration => registration.TournamentId);

        builder
            .HasOne(registration => registration.Sportsman)
            .WithMany(sportsman => sportsman.Registrations)
            .HasForeignKey(registration => registration.SportsmanId);

        builder
            .HasOne(registration => registration.SportCategory)
            .WithMany(sportCategory => sportCategory.Registrations)
            .HasForeignKey(registration => registration.SportCategoryId);
    }
}