using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
           builder.ToTable("team");
           builder.Property(p=>p.TeamName).HasMaxLength(30).IsRequired(true);
           
        }
    }
}