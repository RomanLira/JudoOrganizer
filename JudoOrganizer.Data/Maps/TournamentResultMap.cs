using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class TournamentResultMap
{
    public TournamentResultMap(EntityTypeBuilder<TournamentResult> builder)
    {
        builder.HasKey(tournamentResult => tournamentResult.Id);
        
        builder
            .HasOne(tournamentResult => tournamentResult.Tournament)
            .WithOne()
            .HasForeignKey<TournamentResult>(tournamentResult => tournamentResult.TournamentId);
    }
}