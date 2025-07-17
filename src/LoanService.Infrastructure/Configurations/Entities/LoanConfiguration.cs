using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.Configurations.Entities;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(l => l.Currency).IsRequired().HasMaxLength(10);
        builder.Property(l => l.Status).IsRequired();
        builder.Property(l => l.Type).IsRequired();
        builder.Property(l => l.RequestDate).IsRequired();
        builder.HasOne(l => l.User)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(l => l.DecisionByUser)
            .WithMany(u => u.Decisions)
            .HasForeignKey(l => l.DecisionByUserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.ToTable("Loans");
    }
} 
