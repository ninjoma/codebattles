
using System.Text.Json.Serialization;

namespace codebattle_api.DTO
{
    public class CodeDTO {
        public int? BattleId { get; set; }
        
        public string? Code { get; set; }
    }

    public class CodeResponseDTO {
        public string? stdout { get; set; } 
        public string? time { get; set; }
        public int memory { get; set; }
        public string? stderr { get; set; }
        public string? token { get; set; }
        public string? compile_output { get; set; }
        public string? message { get; set; }
        public CodeResponseStatusDTO? status { get; set; }
    }

    public class CodeResponseStatusDTO {
        public int id { get; set; }
        public string? description { get; set; }
    }
}