using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using codebattle_api.Enums;

namespace codebattle_api.Entities
{
    public class Game : Entity
    {
        [Required]
        public string? Result { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public LanguageEnum Language { get; set; }

        public int? WinnerId { get; set; }

        [ForeignKey(nameof(WinnerId))]
        public User? Winner { get; set; }

        [Required]
        public int GameModeId { get; set; }

        [ForeignKey(nameof(GameModeId))]
        public GameMode? GameMode { get; set; }

        public virtual ICollection<Participant>? Participants { get; set; }
    }


}