using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using FinalProject.Application.Interfaces.Services.TokenServices;
using FinalProject.Application.Models.JwtToken;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;
using System.Security.Claims;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommandRequest, BaseResponse<Token>>
    {
        private readonly IUserQueryRepository _repository;
        private readonly IGenerateToken _tokenGenerater;

        public CheckUserCommandHandler(IUserQueryRepository repository, IGenerateToken tokenGenerater)
        {
            _repository = repository;
            _tokenGenerater = tokenGenerater;
        }

        public async Task<BaseResponse<Token>> Handle(CheckUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Claim> claims = new List<Claim>();
                if(request.Email == "admin" && request.Password == "admin")//eğer admin girişi yapılırsa ona rolünü belirtiyoruz ve token dönüyoruz.
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim("Id", "0"));
                    Token token1 = _tokenGenerater.CreateAccessToken(5, claims);
                    return new BaseResponse<Token>(token1);
                }
                List<User> users = _repository.GetAll();
                User user = users.FirstOrDefault(x => x.Email == request.Email);
                if (user is null || user.Password != request.Password)
                {
                    return new BaseResponse<Token>("Wrong Password or Email");
                }
                claims.Add(new Claim(ClaimTypes.Role, user.Role));
                claims.Add(new Claim("Id", user.Id.ToString()));
                Token token = _tokenGenerater.CreateAccessToken(5, claims);

                return new BaseResponse<Token>(token);
            }
            catch (Exception ex)
            {
                Log.Error("CheckUserCommandHandler", ex);
                return new BaseResponse<Token>(ex.Message);
            }
        }
    }
}
