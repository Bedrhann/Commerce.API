using FinalProject.Application.Models.JwtToken;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandRequest : IRequest<BaseResponse<Token>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
