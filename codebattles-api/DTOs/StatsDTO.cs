namespace codebattle_api.DTO
{
    public class statsDTO {
        public int TotalBattles { get; set; }
        public int WonBattles { get; set; }
        public double WonbattlesRatio { get; set; } 
        public int FastestWin { get; set; }
        public int WonInRow { get; set; }
    }
}