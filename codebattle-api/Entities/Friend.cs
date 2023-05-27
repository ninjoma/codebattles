using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Friend : Entity
    {
        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required]
        public int FriendUserId { get; set; }

        [ForeignKey(nameof(FriendUserId))]
        public User? UserFriend { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AddDate { get; set; }
    }
}