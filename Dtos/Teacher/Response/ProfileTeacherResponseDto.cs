using Cimo.Dtos.Shared;

namespace Cimo.Dtos.Teacher.Response
{
    public class ProfileTeacherResponseDto
    {
        public Guid Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? FullName { get; set; }

        public string? LastName { get; set; }
        public string? Username { get; set; }
        public TeacherDetailDto TeacherDetail { get; set; }
        public ICollection<ClassDto> Class { get; set; }

    }


}
