using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.Configurations.Entities;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(255);
        builder.Property(e => e.PersonalId).IsRequired().HasMaxLength(11);
        builder.Property(e => e.DateOfBirth).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(255);
        builder.ToTable("Users");
    }
}
