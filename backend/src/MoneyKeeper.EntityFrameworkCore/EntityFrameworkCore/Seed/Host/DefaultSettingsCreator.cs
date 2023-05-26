using System.Linq;
using Abp.Configuration;
using Abp.Localization;
using Microsoft.EntityFrameworkCore;

namespace MoneyKeeper.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly MoneyKeeperDbContext _context;

        public DefaultSettingsCreator(MoneyKeeperDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en", null);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
