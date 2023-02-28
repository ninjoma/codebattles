using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Participant : Entity {
        public User User { get; set; }
        public double Score {get; set; }
    }
}