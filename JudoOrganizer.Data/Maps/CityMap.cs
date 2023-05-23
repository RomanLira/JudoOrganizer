using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class CityMap
{
    public CityMap(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(city => city.Id);
        builder
            .HasOne(city => city.Country)
            .WithMany(country => country.Cities)
            .HasForeignKey(city => city.CountryId);
    }
}