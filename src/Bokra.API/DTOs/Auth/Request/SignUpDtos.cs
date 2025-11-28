namespace Bokra.API.DTOs.Auth.Request
{
    public class SignUpDtos
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
