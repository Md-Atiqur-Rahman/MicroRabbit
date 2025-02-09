using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Repository;

public class TransferLogRepository : ITransferLogRepository
{
    private readonly TranserDBContext _context;

    public TransferLogRepository(TranserDBContext context)
    {
        _context = context;
    }

    public void Add(TransferLog transferLog)
    {
        _context.TransferLogs.Add(transferLog);
        _context.SaveChanges();
    }

    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _context.TransferLogs;
    }
}
