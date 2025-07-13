namespace Cimo.Dtos.Shared
{
    public class StudentDto
    {
        public Guid? Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FirstName { get; set; }
        public string? FullName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateOnly? Birthday { get; set; }
        //public List<UserDto> Parents { get; set; }
    }
}
