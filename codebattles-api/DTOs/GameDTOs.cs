using codebattle_api.Enums;

namespace codebattle_api.DTO
{
    public class GameDTO : BaseDTO
    {
        public string? Result { get; set; }
        public string? Name { get; set; }
        public int LanguageId { get; set; }
        public int GameModeId { get; set; }
        public int? WinnerId { get; set; }
        public GameStatusEnum GameStatus { get; set; }
    }

    public class GameDetailDTO : GameDTO {
        public virtual ICollection<ParticipantDTO>? Participants { get; set; }
        public UserDTO? Winner { get; set; }
        public GameModeDTO? GameMode { get; set; }
        public LanguageDTO? Language { get; set; }
    }
}