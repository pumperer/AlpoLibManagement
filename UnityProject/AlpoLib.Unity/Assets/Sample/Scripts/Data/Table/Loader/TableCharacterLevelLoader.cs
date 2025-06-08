using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record CharacterLevelBase : TableDataBase
    {
        [DataColumn("grade")]
        public int Grade { get; set; }
        
        [DataColumn("level")]
        public int Level { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }

    public interface ITableCharacterLevelMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Character_Level")]
    public class TableCharacterLevelLoader : ThreadedTableDataLoader<CharacterLevelBase>, ITableCharacterLevelMapper
    {
        protected override void PostProcess(IEnumerable<CharacterLevelBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}