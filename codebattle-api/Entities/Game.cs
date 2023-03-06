using System.ComponentModel.DataAnnotations;
using codebattle_api.Enums;

namespace codebattle_api.Entities
{
    public class Game : Entity
    {
        public string Result { get; set; }
        public string Name { get; set; }
        public LanguageEnum Language { get; set; }
        public DateTime CreationDate { get; set; }
        public User Winner { get; set; }
        public GameMode GameMode { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }


}