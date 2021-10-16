using Microsoft.AspNetCore.Builder;

using MultiTenancy.Core.Models;
using MultiTenancy.Infrastructure.Middlewares;

namespace MultiTenancy.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultiTenancy<T>(this IApplicationBuilder builder) where T : Tenant 
            => builder.UseMiddleware<TenantMiddleware<T>>();

        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder) 
            => builder.UseMiddleware<TenantMiddleware<Tenant>>();
    }
}
