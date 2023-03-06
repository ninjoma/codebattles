using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Step : Entity {
        public GameMode GameMode { get; set; }
        public string Result { get; set; }
    }
}