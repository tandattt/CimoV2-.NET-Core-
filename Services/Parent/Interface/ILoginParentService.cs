using Cimo.Dtos.Parent.Request;
using Cimo.Dtos.Parent.Response;

namespace Cimo.Services.Parent.Interface
{
    public interface ILoginParentService
    {
        Task<bool> SendOtp(LoginParentRequestDto dto,int otp);
        Task<bool> VerifyOtp(VerifyOtpParentRequestDto dto);
        Task<LoginParentResponseDto> CreateTokenParent(string phone);
    }
}
