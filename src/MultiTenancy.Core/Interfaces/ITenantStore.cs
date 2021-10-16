using System.Threading.Tasks;

using MultiTenancy.Core.Models;

namespace MultiTenancy.Core.Interfaces
{
    public interface ITenantStore<T> where T : Tenant
    {
        Task<T> GetTenantAsync(string identifier);
    }
}
