namespace codebattle_api.DTO
{
    public class FriendDTO : BaseDTO {
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }

    public class FriendDetailDTO : FriendDTO {
        public UserDTO? User { get; set; }
    }
}