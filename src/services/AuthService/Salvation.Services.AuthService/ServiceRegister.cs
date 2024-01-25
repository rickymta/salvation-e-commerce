using Microsoft.Extensions.DependencyInjection;
using Salvation.Library.Common;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Services.Abstractions;
using Salvation.Library.Services.Implementations;

namespace Salvation.Library.Services
{
    public static class ServiceProviderRegister
    {
        public static void RegisterServiceProviders(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.RegisterProviders();
        }
    }
}
