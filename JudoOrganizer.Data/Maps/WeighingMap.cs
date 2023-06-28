using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class WeighingMap
{
    public WeighingMap(EntityTypeBuilder<Weighing> builder)
    {
        builder.HasKey(weighing => weighing.Id);

        builder
            .HasOne(weighing => weighing.Tournament)
            .WithMany(tournament => tournament.Weighing)
            .HasForeignKey(weighing => weighing.TournamentId);

        builder
            .HasOne(weighing => weighing.Sportsman)
            .WithMany(sportsman => sportsman.Weighing)
            .HasForeignKey(weighing => weighing.SportsmanId);

        builder
            .HasOne(weighing => weighing.SportCategory)
            .WithMany(sportCategory => sportCategory.Weighing)
            .HasForeignKey(weighing => weighing.SportCategoryId);
    }
}