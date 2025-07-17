using System.Reflection;
using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoanService.Infrastructure.Data;
public class LoanDbContext: IdentityDbContext<
    User, 
    Role,
    int,
    IdentityUserClaim<int>,
    IdentityUserRole<int>, 
    IdentityUserLogin<int>,
    IdentityRoleClaim<int>,
    IdentityUserToken<int>>
{
    public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Loan> Loans { get; set; }
}
