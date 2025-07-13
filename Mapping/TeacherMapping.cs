
using AutoMapper;
using Cimo.Models;
using Cimo.Dtos.Teacher.Response;
using Cimo.Dtos.Shared;
namespace Cimo.Mapping
{
    public class TeacherMapping : Profile
    {
        public TeacherMapping()
        {
            CreateMap<User, ProfileTeacherResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            CreateMap<TeacherDetail, TeacherDetailDto>();
            CreateMap<SubjectGroup, SubjectGroupDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            CreateMap<AcademicLevel, AcademicLevelDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            //CreateMap<ClassroomSubjectTeacher, ClassTeacherDto>();
            CreateMap<Classroom, ClassDto>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
        }
    }
}
