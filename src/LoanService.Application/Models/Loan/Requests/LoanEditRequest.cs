using System.ComponentModel.DataAnnotations;
using LoanService.Domain.Common;
using LoanService.Application.Models.Common;

namespace LoanService.Application.Models.Loan.Requests;

public class LoanEditRequest
{
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive.")]
    public decimal Amount { get; set; }

    [Required]
    [CurrencyValidation]
    public string Currency { get; set; } = string.Empty;

    [Required]
    [LoanTypeValidation]
    public LoanType Type { get; set; }

    [Range(1, 120, ErrorMessage = "Period must be between 1 and 120 months.")]
    public int PeriodMonths { get; set; }
} 