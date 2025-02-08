using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {

        

        //Domain Bus
        services.AddTransient<IEventBus, RabbitmqBus>();

        //Domain Banking Commands
        services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


        //Application Layer
        services.AddTransient<IAccountService, AccountService>();

        // Data

        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<BankingDBContext>();
    }

}
