using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TarkerYlt.Booking.Application.External.SendGridEmail;
using TarkerYlt.Booking.External.SendGridEmail;

namespace TarkerYlt.Booking.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            return services;
        }
    }
}
