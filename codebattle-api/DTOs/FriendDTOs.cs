namespace codebattle_api.DTO
{
    public class FriendDTO : BaseDTO {
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public DateTime AddDate { get; set; }

    }

    public class FriendDetailDTO : FriendDTO {
        public UserDTO? UserFriend { get; set; }
        public UserDTO? User { get; set; }
    }
}