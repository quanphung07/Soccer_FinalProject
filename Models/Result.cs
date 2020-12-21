using System.ComponentModel.DataAnnotations;

namespace FinalTest.Models
{
    public class Result
    {
        
        public int MatchID { get; set; }
        public int HomeRes { get; set; }
        public int AwayRes{get;set;}
        public virtual Match Match{get;set;}
        
        
    }
}