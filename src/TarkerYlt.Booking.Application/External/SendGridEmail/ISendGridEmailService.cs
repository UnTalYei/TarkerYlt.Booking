using TarkerYlt.Booking.Domain.Models.SendGridEmail;

namespace TarkerYlt.Booking.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
        Task<bool> Execute(SendGridEmailRequestModel model);
    }
}
