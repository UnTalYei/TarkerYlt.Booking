namespace TarkerYlt.Booking.Application.Database.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}
