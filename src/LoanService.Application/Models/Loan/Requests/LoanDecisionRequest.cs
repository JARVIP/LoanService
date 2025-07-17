namespace LoanService.Application.Models.Loan.Requests;

public class LoanDecisionRequest
{
    public int LoanId { get; set; }
    public int DecisionByUserId { get; set; }
    public bool IsApproved { get; set; }
} 