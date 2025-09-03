using BattleGameWebAPI.Data;
using BattleGameWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BattleGameWebAPI.Services.PlayerProfiles
{
    public class DatabaseProfileService : IProfileService
    {
        private BattleGameDatabase m_db;
        private PasswordHasher<string> m_passwordHasher = new PasswordHasher<string>();
        private PlayerProfileFactory m_profileFactory = new PlayerProfileFactory();

        public DatabaseProfileService(BattleGameDatabase db)
        {
            m_db = db;
        }

        public async Task<PlayerProfile> GetOrCreateProfile(string name, string password)
        {
            string hashedPassword = HashPassword(name, password);

            PlayerProfile? player = await m_db.Profiles
                .Where(p => p.Name.ToLower() == name.ToLower() && p.Password == hashedPassword)
                .FirstOrDefaultAsync();

            if (player == null)
            {
                player = m_profileFactory.CreateNewProfile(name, hashedPassword);
                m_db.Profiles.Add(player);
                await m_db.SaveChangesAsync();
            }

            return player;
        }

        private string HashPassword(string name, string password)
        {
            return m_passwordHasher.HashPassword(name, password);
        }
    }
}
