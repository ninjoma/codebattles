using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Participant : Entity
    {

        #region User

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        #endregion User

        #region Game

        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game? Game { get; set; }

        #endregion Game

        [DefaultValue(0)]
        public int CurrentStep { get; set; }
        
        public double Score { get; set; }
    }
}