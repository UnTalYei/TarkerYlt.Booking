using FluentValidation;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;

namespace TarkerYlt.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(10);
        }
    }
}
