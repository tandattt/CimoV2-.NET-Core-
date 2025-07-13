using Cimo.Dtos.Teacher.Response;
using Cimo.Models;
using Cimo.Services.Teacher.Interface;
using Hotel_Management.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cimo.Services.Teacher
{
    public class FutureTeacherService : IFutureTeacherService
    {
        private readonly AppDbContext _dbContext;
        public FutureTeacherService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FutureTeacherResponseDto>> GetListFuture(byte[] class_id, byte[] user_id)
        {
            var role_class = await _dbContext.ClassroomTeacherRoles
                //.Include(cl => cl.Role)
                .FirstOrDefaultAsync(cl => cl.TeacherDetail == user_id && cl.ClassroomId == class_id);
            if (role_class == null)
            {
                throw new NotFoundException("giáo viên không có vai trò trong lớp học hoặc lớp học không tồn tại."); // hoặc throw custom exception nếu bạn muốn
            }
            var role_future = await _dbContext.FeatureUserAccesses
                .Include(f => f.FeatureSetting)
                .Where(f => f.RoleId == role_class.RoleId)
                .Select(f => new FutureTeacherResponseDto
                {
                    Key = f.FeatureSetting.Name,
                    Value = f.IsActive
                })
                .ToListAsync();
            return role_future;
        }
    }
}
