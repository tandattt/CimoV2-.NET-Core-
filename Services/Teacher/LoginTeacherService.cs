using AutoMapper;
using Cimo.Dtos;
using Cimo.Dtos.Teacher.Response;
using Cimo.Dtos.Teacher.Resquest;
using Cimo.Exceptions;
using Cimo.Models;
using Cimo.Services.Teacher.Interface;
using Hotel_Management.Exceptions;
using Hotel_Management.Utils;
using Microsoft.EntityFrameworkCore;

namespace Cimo.Services.Teacher
{
    public class LoginTeacherService : ILoginTeacherService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        //private readonly 
        public LoginTeacherService(AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<LoginTeacherResponseDto> LoginTeacher(LoginTeacherRequestDto dto)
        {
            var user = await _dbContext.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null)
            {
                throw new NotFoundException("Tài khoản không tồn tại");
            }
            else if (user.IsDeleted == true) 
            {
                throw new ForBidenException("Tài khoản đã bị khóa");
            }
            else if(user.Password != dto.Password)
            {
                throw new UnauthorizedException("Sai mật khẩu");
            }
            //var user_role = new List<>
            var payloadDto = _mapper.Map<JwtPayloadDto>(user);
            //Console.WriteLine("UserRoles.Count: " + user.UserRoles.Count);

            //foreach (var ur in user.UserRoles)
            //{
            //    Console.WriteLine($"- Role: {ur.Role?.Name}");
            //}

            //var payload = new Dictionary<string, object>
            //{
            //    //{ "sub",  new Guid(user.Id).ToString() },
            //    //{"authorities", user.UserRoles.Select(r => r.Role.Name).ToArray()}
            //    ["sub"] = payloadDto.Sub,
            //    ["authorities"] = payloadDto.Authorities

            //};
            string token = JWTUtil.GenerateToken(payloadDto);
            var response = new LoginTeacherResponseDto
            {
                //message = "Đăng nhập thành công",
                token = token
            };
            return response;
        }
    }
}
