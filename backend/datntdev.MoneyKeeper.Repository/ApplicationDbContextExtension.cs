using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace datntdev.MoneyKeeper.Repository
{
	public static class ApplicationDbContextExtension
	{
		public static void AddPostgreSqlDbContext(
			this IServiceCollection services, IConfigurationRoot configuration)
		{
			services.AddDbContext<ApplicationDbContext>(opt =>
				opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
		}
	}
}
