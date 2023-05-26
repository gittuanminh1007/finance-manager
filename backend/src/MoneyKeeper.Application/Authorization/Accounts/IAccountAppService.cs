using System.Threading.Tasks;
using Abp.Application.Services;
using MoneyKeeper.Authorization.Accounts.Dto;

namespace MoneyKeeper.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<RegisterOutput> Register(RegisterInput input);
    }
}
