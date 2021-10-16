using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

using MultiTenancy.Core.Models;
using MultiTenancy.Core.Interfaces;
using MultiTenancy.Infrastructure.Accessors;
using MultiTenancy.Infrastructure.Services;

namespace MultiTenancy.Infrastructure.Builders
{
    public class TenantBuilder<T> where T : Tenant
    {
        private readonly IServiceCollection _services;

        public TenantBuilder(IServiceCollection services)
        {
            services.AddTransient<TenantAccessService<T>>();
            this._services = services;
        }

        public TenantBuilder<T> WithResolutionStrategy<V>(ServiceLifetime lifetime = ServiceLifetime.Transient) where V : class, ITenantResolutionStrategy
        {
            this._services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services.TryAddSingleton<ITenantAccessor<Tenant>, TenantAccessor<Tenant>>();
            this._services.Add(ServiceDescriptor.Describe(typeof(ITenantResolutionStrategy), typeof(V), lifetime));
            return this;
        }

        public TenantBuilder<T> WithStore<V>(ServiceLifetime lifetime = ServiceLifetime.Transient) where V : class, ITenantStore<T>
        {
            this._services.Add(ServiceDescriptor.Describe(typeof(ITenantStore<T>), typeof(V), lifetime));
            return this;
        }
    }
}