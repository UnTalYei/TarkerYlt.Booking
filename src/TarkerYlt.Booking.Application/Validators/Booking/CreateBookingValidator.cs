using FluentValidation;
using TarkerYlt.Booking.Application.Database.Booking.Commands.CreateBooking;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;

namespace TarkerYlt.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.Type).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
        }
    }
}
