using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class MatchResultMap
{
    public MatchResultMap(EntityTypeBuilder<MatchResult> builder)
    {
        builder.HasKey(matchResult => matchResult.Id);

        builder
            .HasOne(matchResult => matchResult.TournamentResult)
            .WithMany(tournamentResult => tournamentResult.MatchResults)
            .HasForeignKey(matchResult => matchResult.TournamentResultId);
        
        builder
            .HasOne(matchResult => matchResult.Match)
            .WithOne()
            .HasForeignKey<MatchResult>(matchResult => matchResult.MatchId);
        
        builder
            .HasOne(matchResult => matchResult.Winner)
            .WithMany(sportsman => sportsman.MatchResults)
            .HasForeignKey(matchResult => matchResult.WinnerId);
    }
}