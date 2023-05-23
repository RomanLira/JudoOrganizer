using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class SportsmanMap
{
    public SportsmanMap(EntityTypeBuilder<Sportsman> builder)
    {
        builder.HasKey(sportsman => sportsman.Id);
        builder
            .HasOne(sportsman => sportsman.Club)
            .WithMany(club => club.Sportsmen)
            .HasForeignKey(sportsman => sportsman.ClubId);
        builder
            .HasOne(sportsman => sportsman.Coach)
            .WithMany(coach => coach.Sportsmen)
            .HasForeignKey(sportsman => sportsman.CoachId);
    }
}