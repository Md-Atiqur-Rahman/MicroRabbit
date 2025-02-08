using MicroRabbit.Infra.IoC;

namespace MicroRabbit.Banking.API.Extensions;

public static class Extensions
{
    public static void RegisterServices(this IHostApplicationBuilder builder)
    {
        DependencyContainer.RegisterServices(builder.Services);
    }
}