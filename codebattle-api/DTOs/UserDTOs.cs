namespace codebattle_api.DTO
{
    public class UserDTO : BaseDTO {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Password { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserDetailDTO : UserDTO {
        public virtual ICollection<FriendDTO>? FriendList1 { get; set; }
        public virtual ICollection<FriendDTO>? FriendList2 { get; set; }
        public virtual ICollection<ParticipantDTO>? Participants {get; set;}
    }
}