
namespace BattleGameWebAPI.Models
{
    public class AccountData
    {
        public int Id { get; set; }
        public int Gold { get; set; } = 0;

        public int PlayerProfileId { get; set; }
        public PlayerProfile? PlayerProfile { get; set; }

        public BaseData? Base { get; set; }
    }
}
