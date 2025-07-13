using AutoMapper;
using Cimo.Dtos.Shared;
using Cimo.Dtos.Teacher.Resquest;
using Cimo.Exceptions;
using Cimo.Models;
using Cimo.Services.Teacher.Interface;
using Hotel_Management.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cimo.Services.Teacher
{
    public class AttendanceTeacherService : IAttendanceTeacherService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public AttendanceTeacherService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<StudentDto>> GetStudentsForAttendanceIn(byte[] class_id)
        {
            //Console.WriteLine(DateTime.Today);
            //Console.WriteLine(DateOnly.FromDateTime(DateTime.Today));
            var today = DateOnly.FromDateTime(DateTime.Today);
            string session = "morning";
            if (DateTime.Now.Hour > 12)
            {
                session = "afternoon";
            }
            var academic = await _dbContext.AcademicYears.FirstOrDefaultAsync(ac => ac.StartDate >= today && ac.EndDate >= today);
            if(academic == null)
            {
                throw new NotFoundException("Không tìm thấy năm học phù hợp với ngày hiện tại.");
            }
            //Console.WriteLine(academic.Id.ToString());
            //var s = await _dbContext.StudentClassrooms.ToListAsync();
            //foreach (var student in s)
            //{
            //    Console.WriteLine($"Student: {student.AcademicYearsId}, {student.ClassroomId}");
            //    Console.WriteLine($"data: {class_id}, {academic.Id}");
            //}
            try
            {
                var students = await _dbContext.StudentClassrooms
                    .Include(sc => sc.Student)
                    .Where(sc =>
                        sc.ClassroomId == class_id &&
                        sc.AcademicYearsId == academic.Id &&
                        !sc.Student.StudentAttendances.Any(a => a.Session == session && 
                                                           a.StudentId == sc.Student.Id))
                    .Select(sc => sc.Student)
                    .Select(st => new StudentDto
                    {
                        Id = new Guid(st.Id),
                        AvatarUrl = st.AvatarUrl,
                        FirstName = st.FirstName,
                        FullName = st.FullName,
                        Birthday = st.Birthday,
                        LastName = st.LastName,
                        Gender = st.Gender,
                        //Parents = st.StudentParents
                        //    .Where(sp => sp.ParentDetailUser != null && sp.ParentDetailUser.User != null)
                        //    .Select(sp => new UserDto
                        //    {
                        //        Id = sp.ParentDetailUser.User.Id,
                        //        FirstName = sp.ParentDetailUser.User.FirstName,
                        //        FullName = sp.ParentDetailUser.User.FullName,
                        //        AvatarUrl = sp.ParentDetailUser.User.AvatarUrl,
                        //        Email = sp.ParentDetailUser.User.Email,
                        //        PhoneNumber = sp.ParentDetailUser.User.PhoneNumber
                        //    }).ToList()
                    })
                    .ToListAsync();

                return students;
            }
            catch (NullReferenceException)
            {
                //_logger.LogError(ex, "[GetStudentsForAttendanceIn] Lỗi navigation null.");
                throw new NotFoundException("Không thể truy cập thông tin phụ huynh của học sinh. Dữ liệu bị thiếu.");
            }
            catch (FormatException)
            {
                //_logger.LogError(ex, "[GetStudentsForAttendanceIn] ID định dạng sai.");
                throw new BadRequestException("ID không hợp lệ.");
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[GetStudentsForAttendanceIn] Lỗi hệ thống không xác định.");
                throw new InternalErrorException("Lỗi hệ thống khi truy vấn danh sách học sinh.");
            }
        }
        public async Task<List<StudentDto>> GetStudentsForAttendanceout(byte[] class_id)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            string session = "morning";
            if (DateTime.Now.Hour > 12)
            {
                session = "afternoon";
            }
            var academic = await _dbContext.AcademicYears.FirstOrDefaultAsync(ac => ac.StartDate >= today && ac.EndDate >= today);
            if (academic == null)
            {
                throw new NotFoundException("Không tìm thấy năm học phù hợp với ngày hiện tại.");
            }

            try
            {
                var students = await _dbContext.StudentClassrooms
                    .Include(sc => sc.Student)
                    .Where(sc =>
                        sc.ClassroomId == class_id &&
                        sc.AcademicYearsId == academic.Id &&
                        sc.Student.StudentAttendances.Any(a => a.Session == session &&
                                                           a.StudentId == sc.Student.Id &&
                                                           a.CheckType == "In"))
                    .Select(sc => sc.Student)
                    .Select(st => new StudentDto
                    {
                        Id = new Guid(st.Id),
                        AvatarUrl = st.AvatarUrl,
                        FirstName = st.FirstName,
                        FullName = st.FullName,
                        Birthday = st.Birthday,
                        LastName = st.LastName,
                        Gender = st.Gender,
                        //Parents = st.StudentParents
                        //    .Where(sp => sp.ParentDetailUser != null && sp.ParentDetailUser.User != null)
                        //    .Select(sp => new UserDto
                        //    {
                        //        Id = sp.ParentDetailUser.User.Id,
                        //        FirstName = sp.ParentDetailUser.User.FirstName,
                        //        FullName = sp.ParentDetailUser.User.FullName,
                        //        AvatarUrl = sp.ParentDetailUser.User.AvatarUrl,
                        //        Email = sp.ParentDetailUser.User.Email,
                        //        PhoneNumber = sp.ParentDetailUser.User.PhoneNumber
                        //    }).ToList()
                    })
                    .ToListAsync();

                return students;
            }
            catch (NullReferenceException)
            {
                throw new NotFoundException("Không thể truy cập thông tin phụ huynh của học sinh. Dữ liệu bị thiếu.");
            }
            catch (FormatException)
            {
                throw new BadRequestException("ID không hợp lệ.");
            }
            catch (Exception)
            {
                throw new InternalErrorException("Lỗi hệ thống khi truy vấn danh sách học sinh.");
            }
        }
        public async Task<bool> CreateCheckIn(byte[] student_id, byte[] user_id, CheckInTeacherRequestDto dto)
        {
            string session = "morning";
            if (DateTime.Now.Hour > 12)
            {
                session = "afternoon";
            }
            var checkIn = await _dbContext.StudentAttendances
                .FirstOrDefaultAsync(sa => sa.StudentId == student_id &&
                    sa.CheckType == "In" &&
                    sa.Session == session &&
                    sa.TeacherDetailUserId == user_id
                );
            if (checkIn != null)
            {
                throw new BadRequestException("Học sinh này đã điểm danh vào hôm nay.");
            }
            checkIn = new StudentAttendance
            {
                Id = Guid.NewGuid().ToByteArray(),
                StudentId = student_id,
                CheckType = dto.CheckType,
                CreateAt = DateTime.Now,
                CreateBy = user_id,
                TeacherDetailUserId = user_id,
                Session = session
            };
            _dbContext.StudentAttendances.Add(checkIn);
            try
            {
                int result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                
                throw new InternalErrorException("Lỗi khi lưu dữ liệu. Vui lòng kiểm tra lại.");
            }
            
        }
    }
}
