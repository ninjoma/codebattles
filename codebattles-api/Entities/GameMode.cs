using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class GameMode : Entity {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        [Required]
        public int Time { get; set; }

        public int? MaxPlayers { get; set; }

        public virtual ICollection<Game>? Games {get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }

    }
}