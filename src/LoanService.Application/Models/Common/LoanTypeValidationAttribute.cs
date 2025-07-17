using System.ComponentModel.DataAnnotations;
using LoanService.Domain.Common;

namespace LoanService.Application.Models.Common;

public class LoanTypeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is LoanType type && Enum.IsDefined(typeof(LoanType), type))
            return ValidationResult.Success;
        return new ValidationResult("Invalid loan type.");
    }
} 