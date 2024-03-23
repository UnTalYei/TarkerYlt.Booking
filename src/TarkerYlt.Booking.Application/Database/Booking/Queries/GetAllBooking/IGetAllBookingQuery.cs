namespace TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBooking
{
    public interface IGetAllBookingQuery
    {
        Task<List<GetAllBookingModel>> Execute();
    }
}
