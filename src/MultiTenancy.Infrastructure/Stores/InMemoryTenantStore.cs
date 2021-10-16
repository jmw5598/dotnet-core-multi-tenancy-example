using System.Threading.Tasks;
using System.Linq;

using MultiTenancy.Core.Interfaces;
using MultiTenancy.Core.Models;

namespace MultiTenancy.Infrastructure.Stores
{
    public class InMemoryTenantStore : ITenantStore<Tenant>
    {
        public async Task<Tenant> GetTenantAsync(string identifier)
        {
            var tenant = new[]
            {
                new Tenant{ 
                    Id = "80fdb3c0-5888-4295-bf40-ebee0e3cd8f3", 
                    Identifier = "localhost" 
                }
            }.SingleOrDefault(t => t.Identifier == identifier);

            return await Task.FromResult(tenant);
        }
    }
}
