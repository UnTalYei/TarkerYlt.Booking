namespace TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerById
{
    public interface IGetCustomerByIdQuery
    {
        Task<GetCustomerByIdModel> Execute(int customerId);
    }
}
