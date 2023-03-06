using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class User : Entity {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Participant> Participant {get; set;}
    }
}