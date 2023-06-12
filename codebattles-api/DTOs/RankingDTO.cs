using System.Text.Json.Serialization;

namespace codebattle_api.DTO
{
    public class RankingDTO {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? AvatarBase64 { get; set; }
        public int BattlesWon { get; set; }
    }
}