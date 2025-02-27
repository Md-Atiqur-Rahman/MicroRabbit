﻿using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infrastructure.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {



        //Domain Bus
        services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
        });

        //Subscriptions
        services.AddTransient<TransferEventHandler>();


        // Domain Events
        services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();


        //Domain Banking Commands
        services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


        //Application Layer
        services.AddTransient<IAccountService, AccountService>();

        // Data

        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<BankingDBContext>();


        //Application Layer
        services.AddTransient<ITransferService, TransferService>();

        // Data

        services.AddTransient<ITransferLogRepository, TransferLogRepository>();
        services.AddTransient<TranserDBContext>();
    }


}
