using LoanService.Domain.Repositories;
using LoanService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LoanService.Domain.Entities;
using LoanService.Domain.Common;

namespace LoanService.Infrastructure.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly LoanDbContext _context;
    public LoanRepository(LoanDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Loan>> GetAsync()
    {
        return await _context.Loans.ToListAsync();
    }

    public async Task<Loan?> GetByIdAsync(int id)
    {
        return await _context.Loans.FindAsync(id);
    }

    public async Task AddAsync(Loan loan)
    {
        await _context.Loans.AddAsync(loan);
    }

    public void Update(Loan loan)
    {
        _context.Loans.Update(loan);
    }

    public async Task<IEnumerable<Loan>> GetSentAsync()
    {
        return await _context.Loans.Where(l => l.Status == LoanStatus.Sent).AsNoTracking().ToListAsync();
    }
} 