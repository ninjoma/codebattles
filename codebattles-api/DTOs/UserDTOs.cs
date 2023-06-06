namespace codebattle_api.DTO
{
    public class UserDTO : BaseDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public int? Level { get; set; }
        public int? Experience { get; set; }
    }

    public class UserDetailDTO : UserDTO
    {
        public virtual ICollection<BadgeDTO>? Badges { get; set; }
        public virtual ICollection<GameDTO>? WinnedGames { get; set; }
        public virtual ICollection<FriendDTO>? Friends { get; set; }
        public virtual ICollection<ParticipantDTO>? Participants { get; set; }
    }

    public class UserDTONoPassword
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public int? Level { get; set; }
        public int? Experience { get; set; }
    }
}