using System.ComponentModel.DataAnnotations.Schema;

namespace BattleGameWebAPI.Models
{
    public class SquadData
    {
        public int Id { get; set; }
        public int UnitCount { get; set; } = 1;

        [ForeignKey(nameof(UnitTemplateData))]
        public required int UnitTemplateDataId { get; set; }
        public UnitTemplateData? UnitTemplateData { get; set; }

        [ForeignKey(nameof(BaseData))]
        public required int BaseDataId { get; set; }
        public BaseData? BaseData { get; set; }
    }
}
