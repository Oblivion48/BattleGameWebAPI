using BattleGameWebAPI.Models;

namespace BattleGameWebAPI.Services.PlayerProfiles
{
    public interface IProfileService
    {
        public Task<PlayerProfile> GetOrCreateProfile(string name, string password);
    }
}