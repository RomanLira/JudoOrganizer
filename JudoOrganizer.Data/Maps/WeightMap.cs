using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class WeightMap
{
    public WeightMap(EntityTypeBuilder<Weight> builder)
    {
        builder.HasKey(weight => weight.Id);
    }
}