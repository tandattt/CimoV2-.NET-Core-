using Cimo.Dtos.Teacher.Response;
using Cimo.Dtos.Teacher.Resquest;

namespace Cimo.Services.Teacher.Interface
{
    public interface ILoginTeacherService
    {
        Task<LoginTeacherResponseDto> LoginTeacher(LoginTeacherRequestDto dto);
    }
}
