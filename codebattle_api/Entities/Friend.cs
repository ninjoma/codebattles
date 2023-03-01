using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Friend : Entity {
        public User User { get; set; }
        public DateTime AddDate { get; set; }
    }
}