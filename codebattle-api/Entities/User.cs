using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace codebattle_api.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User : Entity
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Friend>? Friends { get; set; }
        public virtual ICollection<Participant>? Participants { get; set; }
    }
}