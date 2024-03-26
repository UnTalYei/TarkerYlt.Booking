using Microsoft.AspNetCore.Mvc;
using TarkerYlt.Booking.Application.Database.Customer.Commands.CreateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.DeleteCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetAllCustomer;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerById;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.DeleteUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Exceptions;
using TarkerYlt.Booking.Application.Features;

namespace TarkerYlt.Booking.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))] //Capturar errores
    public class CustomerController : ControllerBase
    {
        #region Commands
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand)
        {
            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,  
            [FromServices] IUpdateCustomerCommand updateCustomerCommand)
        {
            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            if (customerId.Equals(0))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await deleteCustomerCommand.Execute(customerId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        #endregion
        #region queries
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();
            if (data == null || data.Count.Equals(0))
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        [HttpGet("getById/{customerId}")]
        public async Task<IActionResult> GetById(
            int customerId,
            [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
        {
            if (customerId == 0) 
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerByIdQuery.Execute(customerId);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        [HttpGet("getByDocumentNumber/{documentNumber}")]
        public async Task<IActionResult> getByDocumentNumber(
            string documentNumber,
            [FromServices] IGetCustomerByDocumentNumberQuery getByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getByDocumentNumberQuery.Execute(documentNumber);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        #endregion
    }
}
