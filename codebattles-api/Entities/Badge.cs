using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Badge : Entity
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Description { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}