using System.Threading.Tasks;
using MoneyKeeper.Configuration.Dto;

namespace MoneyKeeper.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
