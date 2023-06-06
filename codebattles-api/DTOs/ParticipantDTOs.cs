namespace codebattle_api.DTO
{
    public class ParticipantDTO : BaseDTO
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public double Score { get; set; }
        public int CurrentStep { get; set; }
    }
    public class ParticipantDetailDTO : ParticipantDTO
    {
        public UserDTO? User { get; set; }
        public GameDTO? Game { get; set; }
    }
}