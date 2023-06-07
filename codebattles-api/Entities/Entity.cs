using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codebattle_api.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; } = DateTime.Now.ToUniversalTime();
    }
}