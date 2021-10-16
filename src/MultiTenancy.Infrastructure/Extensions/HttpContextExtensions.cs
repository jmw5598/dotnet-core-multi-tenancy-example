using Microsoft.AspNetCore.Http;

using MultiTenancy.Core.Models;
using MultiTenancy.Core.Constants;

namespace MultiTenancy.Infrastructure.Extensions
{
    public static class HttpContextExtensions
    {
        public static T GetTenant<T>(this HttpContext context) where T : Tenant
        {
            if (!context.Items.ContainsKey(Constants.HttpContextTenantKey))
                return null;
            return context.Items[Constants.HttpContextTenantKey] as T;
        }
        
        public static Tenant GetTenant(this HttpContext context)
        {
            return context.GetTenant<Tenant>();
        }
    }
}
