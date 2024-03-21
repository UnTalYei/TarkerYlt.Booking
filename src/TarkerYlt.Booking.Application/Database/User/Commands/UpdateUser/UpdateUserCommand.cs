using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TarkerYlt.Booking.Domain.Entities.User;

namespace TarkerYlt.Booking.Application.Database.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }
        public async Task<UpdateUserModel> Execute (UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            //
            //var entity = await _dataBaseService.User
            //    .FirstOrDefaultAsync(x => x.UserId == model.UserId);

            //if (entity == null)
            //{
            //    return new UpdateUserModel();
            //}

            //entity = _mapper.Map<UserEntity>(model);
            //

            _dataBaseService.User.Update(entity);
            await _dataBaseService.SaveAsync(); 
            return model;
        }

    }
}
