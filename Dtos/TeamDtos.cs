using System.Collections.Generic;
using FinalTest.Models;

namespace FinalTest.Dtos
{
    public class TeamDtos
    {
        
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamImage{get;set;}
        public int StadiumID { get; set; }
        public string StadiumName{get;set;}

    }
}