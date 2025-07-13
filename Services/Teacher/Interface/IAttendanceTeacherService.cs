using Cimo.Dtos.Shared;
using Cimo.Dtos.Teacher.Resquest;

namespace Cimo.Services.Teacher.Interface
{
    public interface IAttendanceTeacherService
    {
        Task<List<StudentDto>> GetStudentsForAttendanceIn(byte[] class_id);
        Task<List<StudentDto>> GetStudentsForAttendanceout(byte[] class_id);
        Task<bool> CreateCheckIn(byte[] student_id, byte[] user_id, CheckInTeacherRequestDto dto);
    }
}
