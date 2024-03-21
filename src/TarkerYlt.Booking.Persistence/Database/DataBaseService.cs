using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkerYlt.Booking.Domain.Entities.User;
using TarkerYlt.Booking.Domain.Entities.Customer;
using TarkerYlt.Booking.Domain.Entities.Booking;
using TarkerYlt.Booking.Persistence.Configuration;
using TarkerYlt.Booking.Application.Database;

namespace TarkerYlt.Booking.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }
        public async Task<bool> SaveAsync ()
        {
            return await SaveChangesAsync() > 0; 
        }

        //Metodo para invocar la configuracion que necesitamos de nuestras entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        //Nuestras modificaciones de configuracion 
        private void EntityConfiguration (ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }

    }
}
