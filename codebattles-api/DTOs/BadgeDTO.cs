namespace codebattle_api.DTO
{
    public class BadgeDTO : BaseDTO {
        
        public string? Name { get; set; }
        
        public string? Description { get; set; }

    }

    public class BadgeDetailDTO : BadgeDTO {
        public virtual ICollection<UserDTO>? Users { get; set; }
    }
}