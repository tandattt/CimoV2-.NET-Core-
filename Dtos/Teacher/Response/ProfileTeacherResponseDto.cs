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
    public class TeacherDetailDto
    {
        public SubjectGroupDto SubjectGroup { get; set; }
        public AcademicLevelDto AcademicLevel { get; set; }
    }
    public class SubjectGroupDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class AcademicLevelDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class ClassTeacherDto
    {
        public ClassDto Classroom { get; set; }
    }
    public class ClassDto
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
    }
}
