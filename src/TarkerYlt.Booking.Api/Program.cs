using Microsoft.EntityFrameworkCore;
using TarkerYlt.Booking.Api;
using TarkerYlt.Booking.Common;
using TarkerYlt.Booking.Application;

using TarkerYlt.Booking.Application.Database;
using TarkerYlt.Booking.Persistence.Database;
using TarkerYlt.Booking.External;
using TarkerYlt.Booking.Persistence;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using Microsoft.AspNetCore.SignalR;
using TarkerYlt.Booking.Application.Database.User.Commands.DeleteUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserById;

var builder = WebApplication.CreateBuilder(args);

//Referenciamos los servicios de inyeccion de dependencias
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapGet("/testService", async (IGetUserByIdQuery service) =>
{
    //var model = new CreateUserModel
    //{
    //    FirstName = "Yeison3",
    //    LastName = "Londoño3",
    //    UserName = "Tabarez3",
    //    Password = "Yei@321"
    //};
    return await service.Execute(2);
});

app.MapPost("/testServiceDelete", async (IDeleteUserCommand service) =>
{
    return await service.Execute(1);
});

app.MapPost("/testServiceUpdate", async (IUpdateUserCommand service) =>
{
    var model = new UpdateUserModel
    {
        UserId = 2,
        FirstName = "Yeison1",
        LastName = "Londoño1",
        UserName = "Tabarez1",
        Password = "Yei@32117"
    };
    return await service.Execute(model);
});

//app.MapPost("/createTest", async (IDataBaseService _dataBaseService) =>
//{
//    var entity = new TarkerYlt.Booking.Domain.Entities.User.UserEntity
//    {
//        FirstName = "Yeison",
//        LastName = "Londoño",
//        UserName = "Tabarez",
//        Password = "Yei@32117",
//    };
//    await _dataBaseService.User.AddAsync(entity);
//    await _dataBaseService.SaveAsync();

//    return "Create OK";
//});

//app.MapGet("/testGet", async (IDataBaseService _dataBaseService) =>
//{
//    var result = await _dataBaseService.User.ToListAsync();
//    return result;
//});

app.Run();
