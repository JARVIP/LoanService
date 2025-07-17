namespace LoanService.Application.Models.Auth.Requests;

public record LoginRequest(
    string Email,
    string Password
); 