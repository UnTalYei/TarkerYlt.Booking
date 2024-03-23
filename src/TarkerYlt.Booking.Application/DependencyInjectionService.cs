using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TarkerYlt.Booking.Application.Configuration;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerById;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.DeleteUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUserPassword;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserById;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;

namespace TarkerYlt.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            #region User
            services.AddSingleton(mapper.CreateMapper()); //Se crea una única instancia del servicio y se comparte en todas las solicitudes o llamadas.
            services.AddTransient<ICreateUserCommand, CreateUserCommand>(); //Se crear una nueva instancia de la clase cada que es requerido //Nos pemite Inyeccion de dependencias
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>(); 
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>(); 
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>(); 
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>(); 
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>(); 
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            #endregion
            return services;
        }
    }
}
