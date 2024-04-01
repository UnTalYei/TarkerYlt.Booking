using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TarkerYlt.Booking.Application.Database;
using TarkerYlt.Booking.Persistence.Database;

namespace TarkerYlt.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options =>
            
            options.UseSqlServer(configuration.GetConnectionString("TarkerYltBookingDb")));
            //options.UseSqlServer(configuration.GetConnectionString("TarkerYltBookingDbAzure")));

            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
