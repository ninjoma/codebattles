
namespace codebattle_api.DTO
{
    public class BaseDTO : GenericDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

    }

    public class GenericDTO
    {

    }
}