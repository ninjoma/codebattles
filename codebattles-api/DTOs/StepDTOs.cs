namespace codebattle_api.DTO
{
    public class StepDTO : BaseDTO
    {
        public int GameModeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int LanguageId { get; set; }
        public string? BoilerPlate { get; set; }

    }

    public class StepDetailDTO : StepDTO {
        public GameModeDTO? GameMode { get; set; }
        public LanguageDTO? Language { get; set; }
        public virtual ICollection<ResultDTO>? Results { get; set; }
    }
}