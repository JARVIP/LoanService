namespace LoanService.Application.Models.Auth.Responses;

public record LoginResponse(
    string Token,
    int UserId,
    string Email
);
