using System.ComponentModel.DataAnnotations;

namespace LoanService.Application.Models.Common;

public class CurrencyValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var currency = value as string;
        var allowed = new[] { "USD", "EUR", "GEL" };
        if (currency != null && allowed.Contains(currency.ToUpperInvariant()))
            return ValidationResult.Success;
        return new ValidationResult("Invalid currency. Allowed: USD, EUR, GEL.");
    }
} 