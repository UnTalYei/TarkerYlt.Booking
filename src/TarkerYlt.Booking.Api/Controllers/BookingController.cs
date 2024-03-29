using Microsoft.AspNetCore.Mvc;
using TarkerYlt.Booking.Application.Database.Booking.Commands.CreateBooking;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBooking;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetAllBookingByDocumentNumber;
using TarkerYlt.Booking.Application.Database.Booking.Queries.GetBookingByType;
using TarkerYlt.Booking.Application.Database.Customer.Queries.GetCustomerByDocumentNumber;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Exceptions;
using TarkerYlt.Booking.Application.Features;

namespace TarkerYlt.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        #region Commands
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand)
        {
            var data = await createBookingCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }
        #endregion
        #region Queries
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllBookingQuery getAllbookingQuery)
        {
            var data = await getAllbookingQuery.Execute();
            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpGet("getByDocumentNumber")]
        public async Task<IActionResult> GetByDocumentNumber(
            [FromQuery] string documentNumber,
            [FromServices] IGetAllBookingByDocumentNumberQuery getAllBookingByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getAllBookingByDocumentNumberQuery.Execute(documentNumber);
            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpGet("getByType")]
        public async Task<IActionResult> GetByType(
            [FromQuery] string type,
            [FromServices] IGetBookingByTypeQuery getBookingByTypeQuery)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingByTypeQuery.Execute(type);
            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        #endregion

    }
}
