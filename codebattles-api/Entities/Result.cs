using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public class Result : Entity
    {
        [Required]
        public string? Value { get; set; }

        [Required]
        public string? Name { get; set; }

        public virtual ICollection<Step>? Steps { get; set; }
    }
}