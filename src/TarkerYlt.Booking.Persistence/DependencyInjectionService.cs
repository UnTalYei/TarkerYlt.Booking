﻿using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
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
            
            options.UseSqlServer(configuration["SqlConnectionStringAzure"]));
            //options.UseSqlServer(configuration["TarkerYltBookingDbAzure"]));

            services.AddScoped<IDataBaseService, DataBaseService>();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
            {
                string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
                string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
                string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

                var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);

                var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(tokenCredentials);

                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
                    SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider }
                });
            }
            else
            {
                var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(new ManagedIdentityCredential());

                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
                    SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider }
                });
            }
            return services;
        }
    }
}
