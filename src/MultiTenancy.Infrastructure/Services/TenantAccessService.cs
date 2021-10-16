using System.Threading.Tasks;

using MultiTenancy.Core.Models;
using MultiTenancy.Core.Interfaces;

namespace MultiTenancy.Infrastructure.Services
{
    public class TenantAccessService<T> where T : Tenant
    {
        private readonly ITenantResolutionStrategy _tenantResolutionStrategy;
        private readonly ITenantStore<T> _tenantStore;

        public TenantAccessService(ITenantResolutionStrategy tenantResolutionStrategy, ITenantStore<T> tenantStore)
        {
            this._tenantResolutionStrategy = tenantResolutionStrategy;
            this._tenantStore = tenantStore;
        }

        public async Task<T> GetTenantAsync()
        {
            var tenantIdentifier = await this._tenantResolutionStrategy.GetTenantIdentifierAsync();
            return await this._tenantStore.GetTenantAsync(tenantIdentifier);
        }
    }    
}
