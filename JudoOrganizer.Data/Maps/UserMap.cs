using JudoOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudoOrganizer.Data.Maps;

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
    }
}