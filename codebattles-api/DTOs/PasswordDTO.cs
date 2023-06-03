namespace codebattle_api.DTO
{
    public class PasswordDTO {
        public string? NewPassword { get; set; }
        public string? RepeatNewPassword { get; set; }

        public string? PasswordResetToken { get; set; }
    }

}