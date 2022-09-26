using FinalProject.Application.DTOs.User;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandRequest : IRequest<BaseResponse<UserCreateDto>>
    {
        public UserCreateDto UserCreateDto { get; set; }
    }
}
