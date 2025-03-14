﻿using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Services;

public class TransferService : ITransferService
{
    private readonly ITransferLogRepository _transferLogRepository;
    private readonly IEventBus _bus;

    public TransferService(ITransferLogRepository transferLogRepository, IEventBus bus)
    {
       _transferLogRepository = transferLogRepository;
       _bus = bus;
    }
    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _transferLogRepository.GetTransferLogs();
    }
}
