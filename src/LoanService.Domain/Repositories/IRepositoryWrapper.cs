namespace LoanService.Domain.Repositories;

public interface IRepositoryWrapper
{
    ILoanRepository Loan { get; }
    Task<int> SaveChangesAsync();
}
