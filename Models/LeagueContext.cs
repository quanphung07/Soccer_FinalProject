using FinalTest.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Models
{
    public class LeagueContext:DbContext
    {
        public LeagueContext(DbContextOptions<LeagueContext> opts):base(opts){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new StadiumConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
        }
        public DbSet<Match> Matches { get;set; }
        public DbSet<Team> Teams{get;set;}
        public DbSet<Player> Players{get;set;}
        public DbSet<Result> Results{get;set;}
        public DbSet<Score> Scores{get;set;}
        public DbSet<Stadium> Stadiums{get;set;}
    }
}