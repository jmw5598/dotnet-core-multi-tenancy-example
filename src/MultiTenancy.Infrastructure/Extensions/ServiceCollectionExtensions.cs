using Microsoft.Extensions.DependencyInjection;

using MultiTenancy.Core.Models;
using MultiTenancy.Infrastructure.Builders;

namespace MultiTenancy.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static TenantBuilder<T> AddMultiTenancy<T>(this IServiceCollection services) where T : Tenant 
            => new TenantBuilder<T>(services);

        public static TenantBuilder<Tenant> AddMultiTenancy(this IServiceCollection services) 
            => new TenantBuilder<Tenant>(services);
    }
}
