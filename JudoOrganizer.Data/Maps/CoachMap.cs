using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class CoachMap
{
    public CoachMap(EntityTypeBuilder<Coach> builder)
    {
        builder.HasKey(coach => coach.Id);
        builder
            .HasOne(coach => coach.Club)
            .WithMany(club => club.Coaches)
            .HasForeignKey(coach => coach.ClubId);
        builder
            .HasOne(coach => coach.User)
            .WithOne()
            .HasForeignKey<Coach>(coach => coach.UserId);
    }
}