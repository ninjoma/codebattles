namespace codebattle_api.DTO
{
    public class StepDTO : BaseDTO
    {
        public int GameModeId { get; set; }
        public string? Result { get; set; }
    }

    public class StepDetailDTO : StepDTO {
        public GameModeDTO? GameMode { get; set; }
    }
}