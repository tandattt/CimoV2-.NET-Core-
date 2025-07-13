using Cimo.Dtos.Shared;
using Cimo.Services.Teacher.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cimo.Controllers.Teacher
{
    [ApiController]
    [Route("teacher")]
    [Authorize(Roles = "ROLE_TEACHER_HOMEROOM, ROLE_TEACHER_SUBJECT")]
    public class ClassroomController : ControllerBase
    {
        private readonly IAttendanceTeacherService _classroomService;
        public ClassroomController(IAttendanceTeacherService classroomService)
        {
            _classroomService = classroomService;
        }
        [HttpGet("{class_id}/attendance-in/students")]
        public async Task<ActionResult<StudentDto>> GetStudentsForAttendanceIn(Guid class_id)
        {
            var class_id_byte = class_id.ToByteArray();
            var result = await _classroomService.GetStudentsForAttendanceIn(class_id_byte);
            return Ok(result);
        }
        [HttpGet("{class_id}/attendance-out/students")]
        public async Task<ActionResult<StudentDto>> GetStudentsForAttendanceOut(Guid class_id)
        {
            var class_id_byte = class_id.ToByteArray();
            var result = await _classroomService.GetStudentsForAttendanceout(class_id_byte);
            return Ok(result);
        }
    }
}
