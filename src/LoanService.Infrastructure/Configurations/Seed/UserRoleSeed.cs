using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.Configurations.Seed;

public class UserRoleSeed : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {
        builder.HasData(
            new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // client
            new IdentityUserRole<int> { UserId = 2, RoleId = 2 }  // manager
        );
    }
} 