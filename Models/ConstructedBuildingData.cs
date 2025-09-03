namespace BattleGameWebAPI.Models
{
    public class ConstructedBuildingData
    {
        public int Id { get; set; }

        public int UnitDataId { get; set; }
        public SquadData? UnitData { get; set; }
    }
}
