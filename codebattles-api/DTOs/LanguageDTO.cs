using System.ComponentModel.DataAnnotations;

namespace codebattle_api.DTO
{
    public class LanguageDTO : BaseDTO
    {
        public string? Name { get; set; }
        public int? Judge0Id { get; set; }
        public string? Validator { get; set; }
    }

    public class LanguageDetailDTO : LanguageDTO
    {
        public virtual ICollection<GameDTO>? Games { get; set; }
        public virtual ICollection<StepDTO>? Steps { get; set; }
    }
}