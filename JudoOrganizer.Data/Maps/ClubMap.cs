using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class ClubMap
{
    public ClubMap(EntityTypeBuilder<Club> builder)
    {
        builder.HasKey(club => club.Id);
        builder
            .HasOne(club => club.City)
            .WithMany(city => city.Clubs)
            .HasForeignKey(club => club.CityId);
    }
}