using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record AchievementSummaryBase : TableDataBase
    {
        [DataCompoundType]
        public Goal Goal { get; set; }
        
        [DataColumn("sequence")]
        public int Sequence { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }

    public interface ITableAchievementSummaryMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Achievement_Summary")]
    public class TableAchievementSummaryLoader : ThreadedTableDataLoader<AchievementSummaryBase>, ITableAchievementSummaryMapper
    {
        protected override void PostProcess(IEnumerable<AchievementSummaryBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}