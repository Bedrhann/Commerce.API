using MediatR;
using Paycore.FinalProject.Domain.Entities;
using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using FinalProject.Application.Wrappers.Response;
using FinalProject.Application.DTOs.User;
using Serilog;

namespace FinalProject.Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<UserCreateDto>>
    {
        private readonly IUserCommandRepository _repository;

        public CreateUserCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<UserCreateDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User NewUser = new()
                {
                    Name = request.UserCreateDto.Name,
                    Surname = request.UserCreateDto.Surname,
                    Email = request.UserCreateDto.Email,
                    Password = request.UserCreateDto.Password,
                    Role = "User",
                    CreationDate = DateTime.UtcNow
                };

                _repository.BeginTransaction();
                _repository.Save(NewUser);
                _repository.Commit();
                _repository.CloseTransaction();

                return new BaseResponse<UserCreateDto>(request.UserCreateDto);
            }
            catch (Exception ex)
            {
                Log.Error("CreateUserCommandHandler", ex);
                _repository.Rollback();
                _repository.CloseTransaction();
                return new BaseResponse<UserCreateDto>(ex.Message);
            }
        }
    }
}
