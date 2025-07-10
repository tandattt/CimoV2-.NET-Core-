using Cimo.Dtos.Teacher.Response;

namespace Cimo.Services.Teacher.Interface
{
    public interface IProfileTeacherService
    {
        Task<ProfileTeacherResponseDto> InforTeacher(byte[] id);
    }
}
