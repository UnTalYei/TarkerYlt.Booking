using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TarkerYlt.Booking.Domain.Entities.User;

namespace TarkerYlt.Booking.Application.Database.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserPasswordCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }
        public async Task<bool> Execute (UpdateUserPasswordModel model)
        {
            var entity = await _dataBaseService.User
                .FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (entity == null)
            {
                return false; 
            }

            entity.Password = model.Password;

            return await _dataBaseService.SaveAsync(); 
        }

    }
}
