using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("match");
            builder.HasOne(h=>h.HomeRes).WithMany(hm=>hm.HomeMatches);
             builder.HasOne(h=>h.AwayRes).WithMany(am=>am.AwayMatches);
             builder.HasOne(s=>s.Stadium).WithMany(m=>m.Matches);
             builder.HasOne(r=>r.Result).WithOne(m=>m.Match).HasForeignKey<Result>(f=>f.MatchID);

        }
    }
}