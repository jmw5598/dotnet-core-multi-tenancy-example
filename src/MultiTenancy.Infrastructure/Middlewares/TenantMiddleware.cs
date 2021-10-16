using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using MultiTenancy.Core.Models;
using MultiTenancy.Core.Constants;
using MultiTenancy.Infrastructure.Services;

namespace MultiTenancy.Infrastructure.Middlewares
{
    internal class TenantMiddleware<T> where T : Tenant
    {
        private readonly RequestDelegate next;

        public TenantMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Items.ContainsKey(Constants.HttpContextTenantKey))
            {
                var tenantService = context.RequestServices.GetService(typeof(TenantAccessService<T>)) as TenantAccessService<T>;
                context.Items.Add(Constants.HttpContextTenantKey, await tenantService.GetTenantAsync());
            }

            //Continue processing
            if (next != null)
                await next(context);
        }
    }
}