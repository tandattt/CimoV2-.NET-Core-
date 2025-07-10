using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cimo.Dtos.Teacher.Response;
using Cimo.Models;
using Cimo.Services.Teacher.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cimo.Services.Teacher
{
    public class ProfileTeacherService : IProfileTeacherService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProfileTeacherService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProfileTeacherResponseDto> InforTeacher(byte[] id)
        {
            var user = await _dbContext.Users
                .Include(u => u.TeacherDetail)
                    .ThenInclude(td => td.AcademicLevel)
                .Include(t => t.TeacherDetail)
                    .ThenInclude(td => td.SubjectGroup)
                .FirstOrDefaultAsync(u => u.Id == id);
            var listClass = await _dbContext.ClassroomSubjectTeachers
                .Where(cl => cl.TeacherDetailId == id)
                .Select(x => x.Classroom)
                .ProjectTo<ClassDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var userMapper = _mapper.Map<ProfileTeacherResponseDto>(user);
            userMapper.Class = listClass;
            return userMapper;
        } 
    }
}
