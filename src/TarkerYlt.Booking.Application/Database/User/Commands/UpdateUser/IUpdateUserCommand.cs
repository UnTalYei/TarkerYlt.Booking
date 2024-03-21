using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkerYlt.Booking.Application.Database.User.Commands.UpdateUserPassword;

namespace TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> Execute(UpdateUserModel model);
    }
}
