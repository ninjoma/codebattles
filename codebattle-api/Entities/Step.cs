using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Step : Entity {
        public int GameModeId { get; set; }

        [ForeignKey(nameof(GameModeId))]
        public GameMode? GameMode { get; set; }

        public string? Result { get; set; }
    }
}