using BattleGameWebAPI.Data;
using BattleGameWebAPI.Models;

namespace BattleGameWebAPI.Services.PlayerProfiles
{
    public class DatabaseProfileService : IProfileService
    {
        private BattleGameDatabase m_db;

        public DatabaseProfileService(BattleGameDatabase db)
        {
            m_db = db;
        }

        public Task<PlayerProfile> GetOrCreateProfile(string name, string password)
        {
            return Task.FromResult(new PlayerProfile() { Name = name, Password = password });
        }
    }
}
