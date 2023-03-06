using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}