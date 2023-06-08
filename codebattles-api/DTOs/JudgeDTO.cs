
using System.Text.Json.Serialization;

namespace codebattle_api.DTO
{
    public class JudgeDTO {
        public string? source_code { get; set; }
        
        public string? language_id { get; set; }

        public string? stdin { get; set; }
    }
}