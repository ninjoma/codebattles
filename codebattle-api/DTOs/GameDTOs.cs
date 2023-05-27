using codebattle_api.Enums;

namespace codebattle_api.DTO
{
    public class GameDTO : BaseDTO
    {
        public string? Result { get; set; }
        public string? Name { get; set; }
        public LanguageEnum Language { get; set; }
        public DateTime CreationDate { get; set; }
        public int GameModeId { get; set; }
        public int? WinnerId { get; set; }
    }

    public class GameDetailDTO : GameDTO {
        public UserDTO? Winner { get; set; }
        public GameModeDTO? GameMode { get; set; }
        public virtual ICollection<ParticipantDTO>? Participants { get; set; }
    }
}