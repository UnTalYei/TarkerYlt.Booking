using Azure.Identity;
using TarkerYlt.Booking.Api;
using TarkerYlt.Booking.Application;
using TarkerYlt.Booking.Common;
using TarkerYlt.Booking.External;
using TarkerYlt.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var keyVaultUrl = builder.Configuration["keyVaultUrl"] ?? string.Empty;

if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
{
    string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCredentials);
}
else
{
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
}

//Referenciamos los servicios de inyeccion de dependencias
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

//string sql = builder.Configuration["SqlConnectionStringLocal"] ?? string.Empty;

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.Run();
