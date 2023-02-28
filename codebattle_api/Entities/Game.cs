using System.ComponentModel.DataAnnotations;

namespace codebattle_api.Entities
{
    public class Game : Entity {
        public string Result { get; set; }
        public string Name { get; set; }
        public LanguageEnum Language { get; set; }
        public DateTime CreationDate { get; set; }
        public User Winner { get; set; }
        public GameMode GameMode {get; set; }
        public virtual ICollection<Participant> Participants {get; set; }
    }

    public enum LanguageEnum {
        JavaScript = 1,
        Python = 2,
        CSharp = 3,
    }
}