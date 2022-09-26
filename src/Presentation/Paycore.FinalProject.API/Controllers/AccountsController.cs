using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Commands.CheckUser;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Models.JwtToken;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paycore.FinalProject.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)//Mediator kütüphanesi ile işlemleri handler nesnelerine yönlendiriyoruz.
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            BaseResponse<UserCreateDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> CheckUser([FromBody] CheckUserCommandRequest request)
        {
            BaseResponse<Token> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
