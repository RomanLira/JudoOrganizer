using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class CountryMap
{
    public CountryMap(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(country => country.Id);
    }
}