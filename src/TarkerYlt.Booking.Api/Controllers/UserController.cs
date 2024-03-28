using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TarkerYlt.Booking.Application.Database.User.Commands.CreateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.DeleteUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUserPassword;
using TarkerYlt.Booking.Application.Database.User.Queries.GetAllUser;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserById;
using TarkerYlt.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
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
        #region Commands
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand)
        {
            var data = await createUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, string.Empty, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand)
        {
            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword(
           [FromBody] UpdateUserPasswordModel model,
           [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand)
        {
            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(
            int userId,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await deleteUserCommand.Execute(userId);
            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        #endregion

        #region Queries
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();
            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpGet("getById/{userId}")]
        public async Task<IActionResult> GetById(
            int userId,
            [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getUserByIdQuery.Execute(userId);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }

        [HttpGet("getByUserNameAndPassword/{userName}/{password}")]
        public async Task<IActionResult> GetByUserNameAndPassword(
            string userName, string password,
            [FromServices] IGetUserByUserNameAndPasswordQuery getUserByUserNameAndPasswordQuery)
        {
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getUserByUserNameAndPasswordQuery.Execute(userName, password);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, string.Empty, data));
        }
        #endregion
    }
}
