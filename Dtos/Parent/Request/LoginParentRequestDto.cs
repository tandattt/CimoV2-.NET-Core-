using System.ComponentModel.DataAnnotations;

namespace Cimo.Dtos.Parent.Request
{
    public class LoginParentRequestDto
    {
        [Phone]
        public string PhoneNumber { get; set; }
    }
    public class VerifyOtpParentRequestDto : LoginParentRequestDto
    {
        public string Otp { get; set; }
    }
}
