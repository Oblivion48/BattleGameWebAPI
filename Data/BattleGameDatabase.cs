using BattleGameWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleGameWebAPI.Data
{
    public class BattleGameDatabase : DbContext
    {
        public DbSet<PlayerProfile> Profiles { get; set; }

        public BattleGameDatabase(DbContextOptions<BattleGameDatabase> options) : base(options)
        {
        }
    }
}