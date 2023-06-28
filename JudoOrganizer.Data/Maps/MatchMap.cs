using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class MatchMap
{
    public MatchMap(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(match => match.Id);
        
        builder
            .HasOne(match => match.Tournament)
            .WithMany(tournament => tournament.Matches)
            .HasForeignKey(match => match.TournamentId);
            
        builder
            .HasOne(match => match.SportCategory)
            .WithMany(sportCategory => sportCategory.Matches)
            .HasForeignKey(match => match.SportCategoryId);
    }
}