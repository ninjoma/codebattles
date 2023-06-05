using System.ComponentModel;
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

        [Required]
        public string? Password { get; set; }

        public string? PasswordResetToken { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Experience { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Level { get; set; }

        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Friend>? Friends { get; set; }
        public virtual ICollection<Game>? WinnedGames { get;  set;}
        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<Badge>? Badges { get; set; }

    }
}