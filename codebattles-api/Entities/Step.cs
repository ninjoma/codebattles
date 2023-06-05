using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Step : Entity
    {
        public int GameModeId { get; set; }

        [ForeignKey(nameof(GameModeId))]


        [Required]
        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language? Language { get; set; }



        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? BoilerPlate { get; set; }


        public virtual ICollection<Game>? Games { get; set; }
        public virtual ICollection<Result>? Results { get; set; }

    }
}