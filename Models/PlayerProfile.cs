namespace BattleGameWebAPI.Models
{
    public class PlayerProfile
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }

        public AccountData? AccountData { get; set; }

        public PlayerProfileDTO ToDTO()
        {
            return new PlayerProfileDTO()
            {
                Name = Name,
                Password = Password,
                ProfileId = Id
            };
        }
    }
}