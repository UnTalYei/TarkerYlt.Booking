using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Exceptions;
using TarkerYlt.Booking.Application.Features;

namespace TarkerYlt.Booking.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand)
        {
            var data = await createUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, null, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand)
        {
            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, null, data));
        }
    }
}
