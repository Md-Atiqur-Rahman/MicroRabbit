using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Data.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly BankingDBContext _context;

    public AccountRepository(BankingDBContext context)
    {
        _context = context;
    }
    public IEnumerable<Account> GetAccounts()
    {
        return _context.Accounts;
    }
}
