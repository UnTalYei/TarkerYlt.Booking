namespace TarkerYlt.Booking.Application.Database.Booking.Queries.GetBookingByType
{
    public interface IGetBookingByTypeQuery
    {
        Task<List<GetBookingByTypeModel>> Execute(string type);
    }
}
