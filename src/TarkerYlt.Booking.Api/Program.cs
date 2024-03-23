using TarkerYlt.Booking.Api;
using TarkerYlt.Booking.Application;
using TarkerYlt.Booking.Common;
using TarkerYlt.Booking.External;
using TarkerYlt.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

//Referenciamos los servicios de inyeccion de dependencias
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers(); 


var app = builder.Build();

app.MapControllers();
app.Run();
