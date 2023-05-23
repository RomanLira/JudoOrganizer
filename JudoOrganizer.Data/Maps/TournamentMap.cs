using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class TournamentMap
{
    public TournamentMap(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(tournament => tournament.Id);
    }
}