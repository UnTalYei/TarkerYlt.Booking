using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TarkerYlt.Booking.Domain.Entities.Customer;

namespace TarkerYlt.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CustomerId);
            entityBuilder.Property(x => x.FullName).IsRequired();
            entityBuilder.Property(x => x.DocumentNumber).IsRequired();

            entityBuilder.HasMany(x => x.Bookings)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId);
        }
    }
}
