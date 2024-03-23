using AutoMapper;
using TarkerYlt.Booking.Application.Database.Booking.Commands.CreateBooking;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerById;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserById;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using TarkerYlt.Booking.Domain.Entities.Booking;
using TarkerYlt.Booking.Domain.Entities.Customer;
using TarkerYlt.Booking.Domain.Entities.User;

namespace TarkerYlt.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User 
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion
            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();
            #endregion
            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            #endregion
        }
    }
}
