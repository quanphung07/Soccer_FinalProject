using System.ComponentModel.DataAnnotations;

namespace FinalTest.Models
{
    public class Result
    {
        
        public int MatchID { get; set; }
        public int Homeres { get; set; }
        public int Awayres{get;set;}
        public virtual Match Match{get;set;}
        
        
    }
}