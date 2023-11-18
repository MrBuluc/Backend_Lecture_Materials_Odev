using Microsoft.Extensions.DependencyInjection;
using YetGenAkbankJump.Shared.Utilities;

namespace YetGenAkbankJump.Shared
{
    public static class DepenencyInjection
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<IDGenerator>();

            return services;
        }
    }
}
