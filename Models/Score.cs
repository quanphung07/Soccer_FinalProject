namespace FinalTest.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}