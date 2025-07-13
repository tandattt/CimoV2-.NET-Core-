using Cimo.Dtos;
using Cimo.Dtos.Teacher.Response;
using Cimo.Services.Teacher.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cimo.Controllers.Teacher
{
    [Route("teacher")]
    [ApiController]
    [Authorize(Roles = "ROLE_TEACHER_HOMEROOM, ROLE_TEACHER_SUBJECT, ROLE_TEACHER")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileTeacherService _profileTeacherService;
        public ProfileController(IProfileTeacherService profileTeacherService)
        {
            _profileTeacherService = profileTeacherService;
        }

        [HttpGet("me")]
        public async Task<ActionResult<ProfileTeacherResponseDto>> ProfileTeacher()
        {
            string? user_id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            byte[]? userIdBytes = user_id != null ? Guid.Parse(user_id).ToByteArray() : null;
            var result = await _profileTeacherService.InforTeacher(userIdBytes);
            //var response = ResponseApi<ProfileTeacherResponseDto>.Success(result);
            return Ok(result);
        }
    }
}
