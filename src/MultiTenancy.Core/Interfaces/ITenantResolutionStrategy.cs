using System.Threading.Tasks;

namespace MultiTenancy.Core.Interfaces
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();
    }
}
