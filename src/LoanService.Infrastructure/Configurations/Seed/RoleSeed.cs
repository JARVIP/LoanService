using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.Configurations.Seed;

public class RoleSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = 1,
                Name = "Client",
                NormalizedName = "CLIENT"
            },
            new Role
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER"
            }
        );
    }
} 