using BattleGameWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleGameWebAPI.Data
{
    public class BattleGameDatabase : DbContext
    {
        public DbSet<PlayerProfile> Profiles { get; set; }
        public DbSet<AccountData> Accounts { get; set; }

        public BattleGameDatabase(DbContextOptions<BattleGameDatabase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupPlayerProfileToAccountDataMapping(ref modelBuilder);
        }

        private void SetupPlayerProfileToAccountDataMapping(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerProfile>()
            .HasOne(p => p.AccountData)
            .WithOne(a => a.PlayerProfile)
            .HasForeignKey<AccountData>(a => a.PlayerProfileId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}