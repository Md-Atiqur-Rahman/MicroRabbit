using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroRabbit.Banking.Data.Context;

public class BankingDBContext: DbContext
{

    //protected override void OnConfiguring
    //   (DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseInMemoryDatabase(databaseName: "BankingDB");
    //}

    public BankingDBContext(DbContextOptions options)
            : base(options)
    {
        LoadAccount();
    }

    public void LoadAccount()
    {
        Account category = new Account() { Id = 1 , AccountType ="Savings", AccountBalance =10000};
        Accounts.Add(category);
        category = new Account() { Id = 2, AccountType = "Checking", AccountBalance = 20000 };
        Accounts.Add(category);
    }

    public List<Account> GetAccount()
    {
        return Accounts.Local.ToList<Account>();
    }
    public DbSet<Account> Accounts { get; set; }
}
