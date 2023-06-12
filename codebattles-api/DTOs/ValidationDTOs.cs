namespace codebattle_api.DTO
{
    public class ValidationDTO : BaseDTO
    {
        public string? EntryValue { get; set; }

        public string? ExitValue { get; set; }

    }

    public class ValidationDetailDTO : ValidationDTO
    {
        public StepDTO? Step { get; set; }
    }
}