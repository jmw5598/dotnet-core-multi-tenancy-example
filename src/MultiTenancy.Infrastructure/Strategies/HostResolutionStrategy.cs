using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using MultiTenancy.Core.Interfaces;

namespace MultiTenancy.Infrastructure.Strategies
{
    public class HostResolutionStrategy : ITenantResolutionStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HostResolutionStrategy(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetTenantIdentifierAsync()
        {
            return await Task.FromResult(_httpContextAccessor.HttpContext.Request.Host.Host);
        }
    }
}
