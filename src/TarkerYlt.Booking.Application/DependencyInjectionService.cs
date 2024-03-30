using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TarkerYlt.Booking.Application.Configuration;
using TarkerYlt.Booking.Application.Database.Booking.Commands.CreateBooking;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBooking;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBookingByDocumentNumber;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetBookingByType;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerById;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.DeleteUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUserPassword;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserById;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using TarkerYlt.Booking.Application.Validators.Booking;
using TarkerYlt.Booking.Application.Validators.Customer;
using TarkerYlt.Booking.Application.Validators.User;

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
            //En .NET, existen tres tipos de alcance para las dependencias:
            //Transient: Se crea una nueva instancia de la dependencia cada vez que se solicita.
            //Scoped: Se crea una nueva instancia de la dependencia por cada solicitud HTTP(en ASP.NET Core) o por cada ámbito de servicio(en aplicaciones no web).
            //Singleton: Se crea una única instancia de la dependencia que se comparte en toda la aplicación.
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
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
            #endregion
            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingQuery, GetAllBookingQuery>();
            services.AddTransient<IGetAllBookingByDocumentNumberQuery, GetAllBookingByDocumentNumberQuery>();
            services.AddTransient<IGetBookingByTypeQuery, GetBookingByTypeQuery>();
            #endregion

            #region validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();
            
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();

            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
            #endregion
            return services;
        }
    }
}
