using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.Configurations.Seed;

public class UserSeed: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
        var requester = new User
        {
            Id = 1,
            UserName = "requester",
            NormalizedUserName = "REQUESTER",
            Email = "requester@example.com",
            NormalizedEmail = "REQUESTER@EXAMPLE.COM",
            EmailConfirmed = true,
            FirstName = "Loan",
            LastName = "Requester",
            PersonalId = "11111111111",
            DateOfBirth = new DateTime(1995, 5, 5),
            SecurityStamp = string.Empty
        };
        requester.PasswordHash = hasher.HashPassword(requester, "Requester123!");

        var approver = new User
        {
            Id = 2,
            UserName = "approver",
            NormalizedUserName = "APPROVER",
            Email = "approver@example.com",
            NormalizedEmail = "APPROVER@EXAMPLE.COM",
            EmailConfirmed = true,
            FirstName = "Loan",
            LastName = "Approver",
            PersonalId = "22222222222",
            DateOfBirth = new DateTime(1992, 2, 2),
            SecurityStamp = string.Empty
        };
        approver.PasswordHash = hasher.HashPassword(approver, "Approver123!");

        builder.HasData(requester, approver);
    }
}
