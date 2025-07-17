using LoanService.Application.Models.Auth.Responses;
using LoanService.Domain.Entities;

namespace LoanService.Application.Mappers;

public interface IAuthMapper
{
    LoginResponse ToLoginResponse(User user, string token);
}

public class AuthMapper : IAuthMapper
{
    public LoginResponse ToLoginResponse(User user, string token)
    {
        return new LoginResponse(
            token,
            user.Id,
            user.Email!
        );
    }
} 