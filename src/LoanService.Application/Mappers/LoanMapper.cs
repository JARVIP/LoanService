using LoanService.Domain.Entities;
using LoanService.Application.Models.Loan.Requests;
using LoanService.Application.Models.Loan.Responses;
using LoanService.Domain.Common;

namespace LoanService.Application.Mappers;

public interface ILoanMapper
{
    Loan ToEntity(LoanCreateRequest request, int userId);
    void MapEditRequestToEntity(LoanEditRequest request, Loan entity);
    LoanResponse ToResponse(Loan entity);
} 

public class LoanMapper : ILoanMapper
{
    public Loan ToEntity(LoanCreateRequest request, int userId)
    {
        return new Loan
        {
            Amount = request.Amount,
            Currency = request.Currency,
            Type = request.Type,
            Status = LoanStatus.Pending,
            RequestDate = DateTime.UtcNow,
            UserId = userId,
            PeriodMonths = request.PeriodMonths
        };
    }

    public void MapEditRequestToEntity(LoanEditRequest request, Loan entity)
    {
        entity.Amount = request.Amount;
        entity.Currency = request.Currency;
        entity.Type = request.Type;
        entity.PeriodMonths = request.PeriodMonths;
    }

    public LoanResponse ToResponse(Loan entity)
    {
        return new LoanResponse
        {
            Id = entity.Id,
            Amount = entity.Amount,
            Currency = entity.Currency,
            Type = entity.Type,
            Status = entity.Status,
            RequestDate = entity.RequestDate,
            UserId = entity.UserId,
            DecisionByUserId = entity.DecisionByUserId,
            DecisionAt = entity.DecisionAt,
            PeriodMonths = entity.PeriodMonths
        };
    }
} 