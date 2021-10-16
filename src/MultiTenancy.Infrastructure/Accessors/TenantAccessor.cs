using Microsoft.AspNetCore.Http;

using MultiTenancy.Core.Interfaces;
using MultiTenancy.Core.Models;
using MultiTenancy.Infrastructure.Extensions;

namespace MultiTenancy.Infrastructure.Accessors
{
    public class TenantAccessor<T> : ITenantAccessor<T> where T : Tenant
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Tenant => _httpContextAccessor.HttpContext.GetTenant<T>();
    }
}
