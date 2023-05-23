using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class DrawMap
{
    public DrawMap(EntityTypeBuilder<Draw> builder)
    {
        builder.HasKey(draw => new {draw.SportsmanId, draw.TournamentId, draw.MatchId});
        
        builder
            .HasOne(draw => draw.Tournament)
            .WithOne()
            .HasForeignKey<Draw>(draw => draw.TournamentId);

        builder
            .HasOne(draw => draw.Sportsman)
            .WithOne()
            .HasForeignKey<Draw>(draw => draw.SportsmanId);

        builder
            .HasOne(draw => draw.Match)
            .WithOne()
            .HasForeignKey<Draw>(draw => draw.MatchId);
    }
}