using System.ComponentModel.DataAnnotations.Schema;

namespace BattleGameWebAPI.Models
{
    public class BaseData
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AccountData))]
        public int AccountDataId { get; set; }

        public List<SquadData> Units { get; set; } = new List<SquadData>();
    }
}
