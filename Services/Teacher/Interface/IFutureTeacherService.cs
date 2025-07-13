using Cimo.Dtos.Teacher.Response;

namespace Cimo.Services.Teacher.Interface
{
    public interface IFutureTeacherService
    {
        Task<List<FutureTeacherResponseDto>> GetListFuture(byte[] class_id, byte[] user_id);
    }
}
