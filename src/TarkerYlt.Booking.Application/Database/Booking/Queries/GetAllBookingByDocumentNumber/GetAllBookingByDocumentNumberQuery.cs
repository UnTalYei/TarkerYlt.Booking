using Microsoft.EntityFrameworkCore;

namespace TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBookingByDocumentNumber
{
    public class GetAllBookingByDocumentNumberQuery : IGetAllBookingByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetAllBookingByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<List<GetAllBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                 }).ToListAsync();
            return result;
        }
    }
}
