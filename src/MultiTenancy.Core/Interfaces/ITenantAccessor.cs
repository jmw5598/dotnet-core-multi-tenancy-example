using MultiTenancy.Core.Models;

namespace MultiTenancy.Core.Interfaces
{
    public interface ITenantAccessor<T> where T : Tenant
    {
        T Tenant { get; }
    }
}
