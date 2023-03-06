using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Tag : Entity{
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GameMode> GameModes { get; set; }
    }
}