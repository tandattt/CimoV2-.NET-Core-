using Cimo.Dtos.Teacher.Resquest;
using Cimo.Services.Teacher.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cimo.Controllers.Teacher
{
    [ApiController]
    [Route("teacher")]
    [Authorize(Roles = "ROLE_TEACHER_HOMEROOM, ROLE_TEACHER_SUBJECT")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceTeacherService _attendanceTeacherService;
        public AttendanceController(IAttendanceTeacherService attendanceTeacherService)
        {
            _attendanceTeacherService = attendanceTeacherService;
        }

        [HttpPost("check-in/{student_id}")]
        public async Task<IActionResult> CheckIn(Guid student_id, CheckInTeacherRequestDto dto)
        {
            byte[]? user_id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToByteArray();
            byte[]? student_id_byte = student_id.ToByteArray();
            var result = await _attendanceTeacherService.CreateCheckIn(student_id_byte, user_id, dto);
            if (!result)
            {
                return BadRequest(new { message = "Điểm danh không thành công" });
            }
            return Ok(new {message = "Điểm danh thành công"});
        }
    }
}
