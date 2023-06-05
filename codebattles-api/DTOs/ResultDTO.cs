namespace codebattle_api.DTO
{
    public class ResultDTO : BaseDTO
    {
        public string? Value { get; set; }
        public string? Name { get; set; }

    }

    public class ResultDetailDTO : ResultDTO
    {
        public virtual ICollection<StepDTO>? Steps { get; set; }
    }
}