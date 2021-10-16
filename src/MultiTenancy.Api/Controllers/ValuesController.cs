using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MultiTenancy.Core.Models;
using MultiTenancy.Infrastructure.Services;
using MultiTenancy.Infrastructure.Extensions;

namespace MultiTenancy.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TenantAccessService<Tenant> _tenantService; 

        public ValuesController(TenantAccessService<Tenant> tenantService)
        {
            this._tenantService = tenantService;
        }

        [HttpGet]
        public async Task<string> GetValue(Guid definitionId)
        {
            return await Task.FromResult(HttpContext.GetTenant().Id);
        }
    }
}