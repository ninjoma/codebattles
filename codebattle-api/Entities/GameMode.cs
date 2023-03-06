using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class GameMode : Entity {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public virtual ICollection<Game> Games {get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}