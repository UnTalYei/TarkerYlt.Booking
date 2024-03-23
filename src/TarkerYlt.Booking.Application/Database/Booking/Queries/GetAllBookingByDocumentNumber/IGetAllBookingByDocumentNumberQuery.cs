namespace TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBookingByDocumentNumber
{
    public interface IGetAllBookingByDocumentNumberQuery
    {
        Task<List<GetAllBookingByDocumentNumberModel>> Execute(string documentNumber);
    }
}
