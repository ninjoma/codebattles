namespace codebattle_api.DTO
{
    public class FriendDTO : BaseDTO {
        public UserDTO User { get; set; }
        public DateTime AddDate { get; set; }
    }
}