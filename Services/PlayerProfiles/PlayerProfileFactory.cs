using BattleGameWebAPI.Models;

namespace BattleGameWebAPI.Services.PlayerProfiles
{
    public class PlayerProfileFactory
    {
        public PlayerProfile CreateNewProfile(string name, string hashedPassword)
        {
            PlayerProfile newProfile = new PlayerProfile()
            {
                Name = name,
                Password = hashedPassword
            };

            newProfile.AccountData = new AccountData()
            {
                Base = new BaseData()
                {
                    Units = new List<SquadData>()
                },
                Gold = 500
            };

            return newProfile;
        }
    }
}
