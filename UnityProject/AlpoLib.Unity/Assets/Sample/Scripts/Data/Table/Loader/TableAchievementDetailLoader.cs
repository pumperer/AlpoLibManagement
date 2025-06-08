using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record AchievementDetailBase : TableDataBase
    {
        [DataColumn("achievement_id")]
        public int AchievementId { get; set; }
        
        [DataColumn("goal_count")]
        public int GoalCount { get; set; }
        
        [DataColumn("reward_group_id")]
        public int RewardGroupId { get; set; }
        
        [DataColumn("sequence")]
        public int Sequence { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }

    public interface ITableAchievementDetailMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Achievement_Detail")]
    public class TableAchievementDetailLoader : ThreadedTableDataLoader<AchievementDetailBase>, ITableAchievementDetailMapper
    {
        protected override void PostProcess(IEnumerable<AchievementDetailBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}