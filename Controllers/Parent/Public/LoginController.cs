
using Cimo.Services.Parent.Interface;
using Hotel_Management.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cimo.Dtos;
using Cimo.Dtos.Parent.Request;
using Cimo.Dtos.Parent.Response;

namespace Cimo.Controllers.Parent.Public
{
    [Route("Parent")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginParentService _loginParentService;
        public LoginController(ILoginParentService loginParentService)
        {
            _loginParentService = loginParentService;
        }

        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtp([FromBody] LoginParentRequestDto dto)
        {
            Random rand = new Random();
            int otp = rand.Next(100000, 999999);
            bool result = await _loginParentService.SendOtp(dto, otp);
            if (!result)
            {
                return BadRequest(ResponseApi<ErrorDto>.Fail(
                    new ErrorDto { Message = "Send otp không thành công" }
                    ));
            }
            return Ok(ResponseApi<SuccessDto>.Success(
                new SuccessDto { Message = $"Send otp thành công {otp}" }
                ));

        }
        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpParentRequestDto dto)
        {
            bool result = await _loginParentService.VerifyOtp(dto);
            if (!result)
            {
                return BadRequest(ResponseApi<ErrorDto>.Fail(
                    new ErrorDto { Message = "Otp không đúng" }
                    ));
            }
            var token = await _loginParentService.CreateTokenParent(dto.PhoneNumber);
            var response = ResponseApi<LoginParentResponseDto>.Success(token);
            return Ok(response);

        }
    }
}
