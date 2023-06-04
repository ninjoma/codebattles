namespace codebattle_api.DTO
{
    public class GameModeDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Time { get; set; }
    }

    public class GameModeDetailDTO : GameModeDTO
    {
        public virtual ICollection<GameDTO>? Games { get; set; }
        public virtual ICollection<StepDTO>? Steps { get; set; }
        public virtual ICollection<TagDTO>? Tags { get; set; }
    }
}