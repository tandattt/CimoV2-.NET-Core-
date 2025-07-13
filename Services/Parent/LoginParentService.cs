using AutoMapper;
using Cimo.Dtos.Common;
using Cimo.Dtos.Parent.Request;
using Cimo.Dtos.Parent.Response;
using Cimo.Exceptions;
using Cimo.Models;
using Cimo.Services.Common.Interface;
using Cimo.Services.Parent.Interface;
using Hotel_Management.Exceptions;
using Hotel_Management.Utils;
using Microsoft.EntityFrameworkCore;

namespace Cimo.Services.Parent
{
    public class LoginParentService : ILoginParentService
    {
        private readonly IRedisCacheService _redisCache;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginParentService(IRedisCacheService redisCache, AppDbContext dbContext, IMapper mapper)
        {
            _redisCache = redisCache;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> SendOtp(LoginParentRequestDto dto,int otp)
        {
            var user = await _dbContext.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber);
            bool isRole = false;
            if (user == null)
            {
                throw new NotFoundException("Số điện thoại không tồn tại");
            }
            else if (user.IsDeleted == true)
            {
                throw new ForBidenException("Tài khoản của bạn đã bị khóa");
            }
            foreach (var ur in user.UserRoles)
            {
                if(ur.Role?.Name == "Parent")
                {
                    isRole = true;
                    break;
                }
            }
            if (!isRole)
            {
                throw new UnauthorizedException("Tài khoản không phải là phụ huynh");
            }
            //Random rand = new Random();
            //int otp = rand.Next(1000, 9999);
            string key = $"otp_{dto.PhoneNumber}";
            
            await _redisCache.SetAsync(key, otp, 5);
            //bool smsSent = await _smsService.SendAsync(phoneNumber, $"Your OTP is: {otp}");

            //if (!smsSent)
            //{
            //    // Nếu gửi SMS thất bại → rollback Redis nếu cần
            //    await _redisCache.RemoveAsync(key);
            //    return false;
            //}
            return true;
            
        }
        public async Task<bool> VerifyOtp(VerifyOtpParentRequestDto dto)
        {
            var key = $"otp_{dto.PhoneNumber}";
            var otp = await _redisCache.GetAsync<int>(key);
            Console.WriteLine(otp);
            if (otp == 0)
            {
                throw new NotFoundException("Otp hết hạn hoặc chưa được gửi");
            }
            else if (otp.ToString() != dto.Otp)
            {
                return false;
            }

            return true;

        }

        public async Task<LoginParentResponseDto> CreateTokenParent(string phone)
        {
            var user = await _dbContext.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.PhoneNumber == phone);

            var payloadDto = _mapper.Map<JwtPayloadDto>(user);

            string token = JWTUtil.GenerateToken(payloadDto);
            var response = new LoginParentResponseDto
            {
                //message = "Đăng nhập thành công",
                token = token
            };
            return response;
        }
    }
}
