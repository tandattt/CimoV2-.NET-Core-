using Cimo.Dtos.Teacher.Response;
using Cimo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Cimo.Services.Teacher.Interface;

namespace Cimo.Controllers.Teacher
{
    [ApiController]
    [Route("teacher")]
    [Authorize(Roles = "ROLE_TEACHER_HOMEROOM, ROLE_TEACHER_SUBJECT")]
    public class FutureController : ControllerBase
    {
        private readonly IFutureTeacherService _futureTeacherService;
        public FutureController(IFutureTeacherService futureTeacherService)
        {
            _futureTeacherService = futureTeacherService;
        }

        [HttpGet("list-future/{class_id}")]
        public async Task<ActionResult<List<FutureTeacherResponseDto>>> ListFuture(Guid class_id) 
        {
            string user_id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            byte[]? userIdBytes = Guid.Parse(user_id).ToByteArray();
            byte[]? classIdBytes = class_id.ToByteArray();
            //return Ok();
            var result = await _futureTeacherService.GetListFuture(classIdBytes, userIdBytes);
            return Ok(result);
        }
    }
}
