using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class WeighingMap
{
    public WeighingMap(EntityTypeBuilder<Weighing> builder)
    {
        builder.HasKey(weighing => new {weighing.SportsmanId, weighing.TournamentId, weighing.SportCategoryId});

        builder
            .HasOne(weighing => weighing.Tournament)
            .WithOne()
            .HasForeignKey<Weighing>(weighing => weighing.TournamentId);

        builder
            .HasOne(weighing => weighing.Sportsman)
            .WithOne()
            .HasForeignKey<Weighing>(weighing => weighing.SportsmanId);

        builder
            .HasOne(weighing => weighing.SportCategory)
            .WithOne()
            .HasForeignKey<Weighing>(weighing => weighing.SportCategoryId);
    }
}