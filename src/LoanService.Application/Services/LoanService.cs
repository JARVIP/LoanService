using LoanService.Application.Models.Loan.Requests;
using LoanService.Application.Models.Loan.Responses;
using LoanService.Application.Mappers;
using LoanService.Domain.Repositories;
using LoanService.Domain.Common;

namespace LoanService.Application.Services;

public interface ILoanService
{
    Task<LoanResponse> CreateLoanAsync(LoanCreateRequest request, int userId);
    Task<LoanResponse> MakeDecisionAsync(LoanDecisionRequest request, int userId);
    Task<LoanResponse> EditLoanAsync(int id, LoanEditRequest request);
    Task<IEnumerable<LoanResponse>> GetSentLoansAsync();
    Task MarkLoanAsSentAsync(int loanId);
}

public class LoanManagementService : ILoanService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILoanMapper _loanMapper;
    public LoanManagementService(IRepositoryWrapper repository, ILoanMapper loanMapper)
    {
        _repository = repository;
        _loanMapper = loanMapper;
    }

    public async Task<LoanResponse> CreateLoanAsync(LoanCreateRequest request, int userId)
    {
        var loan = _loanMapper.ToEntity(request, userId);
        await _repository.Loan.AddAsync(loan);
        await _repository.SaveChangesAsync();
        return _loanMapper.ToResponse(loan);
    }

    public async Task<LoanResponse> MakeDecisionAsync(LoanDecisionRequest request, int userId)
    {
        var loan = await _repository.Loan.GetByIdAsync(request.LoanId);
        if (loan == null)
            throw new InvalidOperationException("Loan not found");
        loan.DecisionByUserId = userId;
        loan.DecisionAt = DateTime.UtcNow;
        loan.Status = request.IsApproved ? LoanStatus.Approved : LoanStatus.Rejected;
        _repository.Loan.Update(loan);
        await _repository.SaveChangesAsync();
        return _loanMapper.ToResponse(loan);
    }

    public async Task<LoanResponse> EditLoanAsync(int id, LoanEditRequest request)
    {
        var loan = await _repository.Loan.GetByIdAsync(id);
        if (loan == null)
            throw new InvalidOperationException("Loan not found");
            
        if(loan.Status != LoanStatus.Pending)
            throw new InvalidOperationException("Loan with status other than pending cannot be edited");
            
        _loanMapper.MapEditRequestToEntity(request, loan);
        _repository.Loan.Update(loan);
        await _repository.SaveChangesAsync();
        return _loanMapper.ToResponse(loan);
    }

    public async Task<IEnumerable<LoanResponse>> GetSentLoansAsync()
    {
        var loans = await _repository.Loan.GetSentAsync();
        return loans.Select(_loanMapper.ToResponse);
    }

    public async Task MarkLoanAsSentAsync(int loanId)
    {
        var loan = await _repository.Loan.GetByIdAsync(loanId);
        if (loan == null)
            throw new InvalidOperationException("Loan not found");
        loan.Status = LoanStatus.Sent;
        _repository.Loan.Update(loan);
        await _repository.SaveChangesAsync();
    }
} 