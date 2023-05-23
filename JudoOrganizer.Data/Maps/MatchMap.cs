using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class MatchMap
{
    public MatchMap(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(match => match.Id);
        
        builder
            .HasOne(match => match.Sportsman)
            .WithMany(sportsman => sportsman.Matches)
            .HasForeignKey(match => match.SportsmanId);
    }
}