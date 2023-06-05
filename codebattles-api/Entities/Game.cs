using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using codebattle_api.Enums;

namespace codebattle_api.Entities
{
    public class Game : Entity
    {

        [Required]
        public LanguageEnum Language { get; set; }

        public int? WinnerId { get; set; }

        [ForeignKey(nameof(WinnerId))]
        public User? Winner { get; set; }

        public string? Result { get; set; }

        [Required]
        public int GameModeId { get; set; }

        [ForeignKey(nameof(GameModeId))]
        public GameMode? GameMode { get; set; }

        [Required]
        [DefaultValue(GameStatusEnum.Waiting)]
        public GameStatusEnum GameStatus { get; set; }

        public virtual ICollection<Participant>? Participants { get; set; }
    }


}