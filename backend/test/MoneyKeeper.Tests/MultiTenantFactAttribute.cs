using Xunit;

namespace MoneyKeeper.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            Skip = "MultiTenancy is disabled.";
        }
    }
}
