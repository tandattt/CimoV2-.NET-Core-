using Cimo.Dtos;
using Cimo.Dtos.Teacher.Response;
using Cimo.Dtos.Teacher.Resquest;
using Cimo.Services.Teacher.Interface;
using Hotel_Management.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cimo.Controllers.Teacher.Public
{
    [Route("Teacher")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginTeacherService _loginTeacherService;
        public LoginController(ILoginTeacherService loginTeacherService)
        {
            _loginTeacherService = loginTeacherService;
        }
        [HttpGet("test")]
        [Authorize(Roles = "ROLE_PRINCIPAL")]
        public IActionResult test()
        {
            var roles = User.Claims
                .Where(c => c.Type == "authorities")
                .Select(c => c.Value)
                .ToList();
            foreach (var r in roles)
            {
                Console.WriteLine("Role: " + r);
            }
            string? user_id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(user_id);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginTeacherRequestDto dto)
        {
            var result = await _loginTeacherService.LoginTeacher(dto);
            var response = ResponseApi<LoginTeacherResponseDto>.Success(result);
            //Console.WriteLine(response);
            return Ok(response);

        }
        
    }
}
