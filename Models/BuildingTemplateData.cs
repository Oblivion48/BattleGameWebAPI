namespace BattleGameWebAPI.Models
{
    public class BuildingTemplateData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeSpan UnitProductionRate { get; set; }
    }
}
