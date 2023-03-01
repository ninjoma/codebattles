namespace codebattle_api.DTO
{
    public class ParticipantDTO : BaseDTO {
        public UserDTO User { get; set; }
        public double Score { get; set; }
        public GameDTO Game { get; set; }
    }
}