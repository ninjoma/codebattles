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

        public Step? Step { get; set; }

    }
}