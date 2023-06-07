using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Validation : Entity
    {
        [Required]
        public string? EntryValue { get; set; }

        [Required]
        public string? ExitValue { get; set; }

        [Required]
        public int StepId { get; set; }

        [ForeignKey(nameof(StepId))]
        public Step? Step { get; set; } = null!;

    }
}