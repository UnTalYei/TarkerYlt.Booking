using Microsoft.EntityFrameworkCore;
using TarkerYlt.Booking.Domain.Entities.User;
using TarkerYlt.Booking.Domain.Entities.Customer;
using TarkerYlt.Booking.Domain.Entities.Booking;

namespace TarkerYlt.Booking.Application.Database
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<BookingEntity> Booking { get; set; }

        Task<bool> SaveAsync();
    }
}
