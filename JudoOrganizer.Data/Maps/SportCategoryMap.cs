using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class SportCategoryMap
{
    public SportCategoryMap(EntityTypeBuilder<SportCategory> builder)
    {
        builder.HasKey(sportCategory => sportCategory.Id);
        
        builder
            .HasOne(sportCategory => sportCategory.Tournament)
            .WithMany(tournament => tournament.SportCategories)
            .HasForeignKey(sportCategory => sportCategory.TournamentId);
        
        builder
            .HasOne(sportCategory => sportCategory.Weight)
            .WithMany(weight => weight.SportCategories)
            .HasForeignKey(sportCategory => sportCategory.WeightId);
    }
}