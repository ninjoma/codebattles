using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Language : Entity {
        [Required]
        public string? Name { get; set; }
        public int Judge0Id { get; set; }

        public string? Validator { get; set; }

        public virtual ICollection<Game>? Games { get; set; }
    }
}