using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context;

public class TranserDBContext : DbContext
{
    public TranserDBContext(DbContextOptions options)
            : base(options)
    {
    }
    public DbSet<TransferLog> TransferLogs { get; set; }
}
