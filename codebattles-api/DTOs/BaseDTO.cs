
using System.Text.Json.Serialization;

namespace codebattle_api.DTO
{
    public class BaseDTO : GenericDTO
    {
        public int Id { get; set; }

        [JsonIgnore]
        public bool? IsActive { get; set; }

        [JsonIgnore]
        public DateTime? CreationDate { get; set; }

    }

    public class GenericDTO
    {

    }
}