using LoanService.Domain.Common;

namespace LoanService.Application.Models.Loan.Responses;

public class LoanResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public LoanType Type { get; set; }
    public LoanStatus Status { get; set; }
    public DateTime RequestDate { get; set; }
    public int? UserId { get; set; }
    public int? DecisionByUserId { get; set; }
    public DateTime? DecisionAt { get; set; }
    public int PeriodMonths { get; set; }
} 