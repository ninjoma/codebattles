namespace codebattle_api.DTO
{
    public class StepDTO : BaseDTO
    {
        public GameModeDTO GameMode { get; set; }
        public string Result { get; set; }
    }
}