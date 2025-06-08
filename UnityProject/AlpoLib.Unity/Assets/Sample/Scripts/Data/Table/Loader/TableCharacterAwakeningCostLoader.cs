using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record CharacterAwakeningCostBase : TableDataBase
    {
        [DataColumn("grade")]
        public int Grade { get; set; }
        
        [DataColumn("gold")]
        public int Gold { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }

    public interface ITableCharacterAwakeningCostMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Character_AwakeningCost")]
    public class TableCharacterAwakeningCostLoader : ThreadedTableDataLoader<CharacterAwakeningCostBase>, ITableCharacterAwakeningCostMapper
    {
        protected override void PostProcess(IEnumerable<CharacterAwakeningCostBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}