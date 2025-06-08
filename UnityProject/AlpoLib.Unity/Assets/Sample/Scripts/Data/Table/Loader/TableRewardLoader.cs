using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record RewardBase : TableDataBase
    {
        [DataColumn("reward_group_id")]
        public int RewardGroupId { get; set; }
        
        [DataCompoundType("reward_")]
        public Reward Reward { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }
    
    public interface ITableRewardMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Reward")]
    public class TableRewardLoader : ThreadedTableDataLoader<RewardBase>, ITableRewardMapper
    {
        protected override void PostProcess(IEnumerable<RewardBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}