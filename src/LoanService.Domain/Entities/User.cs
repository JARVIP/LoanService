using Microsoft.AspNetCore.Identity;

namespace LoanService.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PersonalId { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public ICollection<Loan>? Loans { get; set; }
    public ICollection<Loan>? Decisions { get; set; }
}