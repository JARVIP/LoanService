using LoanService.Domain.Repositories;
using LoanService.Infrastructure.Data;

namespace LoanService.Infrastructure.Repositories;

public class RepositoryWrapper: IRepositoryWrapper
{
    private readonly LoanDbContext _context;
    private ILoanRepository? _loanRepository;

    public RepositoryWrapper(LoanDbContext context)
    {
        _context = context;
    }

    public ILoanRepository Loan => _loanRepository ??= new LoanRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
