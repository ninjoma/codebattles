namespace codebattle_api.DTO
{
    public class TagDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TagDetailDTO : TagDTO
    {
        public virtual ICollection<GameModeDTO> GameModes { get; set; }
    }
}