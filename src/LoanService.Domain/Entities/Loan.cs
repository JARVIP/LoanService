using LoanService.Domain.Common;

namespace LoanService.Domain.Entities;

public class Loan
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public LoanStatus Status { get; set; } = LoanStatus.Pending;
    public LoanType Type { get; set; } = LoanType.Quick;
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int? DecisionByUserId { get; set; }
    public User? DecisionByUser { get; set; }
    public DateTime? DecisionAt { get; set; }
    public int PeriodMonths { get; set; }
} 