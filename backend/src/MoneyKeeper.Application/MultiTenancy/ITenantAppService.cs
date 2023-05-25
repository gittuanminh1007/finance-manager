using Abp.Application.Services;
using MoneyKeeper.MultiTenancy.Dto;

namespace MoneyKeeper.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

