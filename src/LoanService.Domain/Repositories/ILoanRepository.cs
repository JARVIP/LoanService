using LoanService.Domain.Entities;

namespace LoanService.Domain.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAsync();
    Task<Loan?> GetByIdAsync(int id);
    Task AddAsync(Loan loan);
    void Update(Loan loan);
    Task<IEnumerable<Loan>> GetSentAsync();
} 