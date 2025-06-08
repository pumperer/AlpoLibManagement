using System.Collections;
using System.Collections.Generic;
using alpoLib.Core.Foundation;
using alpoLib.Data;
using alpoLib.Data.Serialization;

namespace alpoLib.Sample.Data
{
    public record CharacterExpBase : TableDataBase
    {
        [DataColumn("grade")]
        public int Grade { get; set; }
        
        [DataColumn("level")]
        public int Level { get; set; }
        
        [DataColumn("exp")]
        public int Exp { get; set; }
        
        [DataColumn("status")]
        public CustomBoolean Status { get; set; }
    }

    public interface ITableCharacterExpMapper : ITableDataMapperBase
    {
        
    }
    
    [TableDataSheetName("Character_Exp")]
    public class TableCharacterExpLoader : ThreadedTableDataLoader<CharacterExpBase>, ITableCharacterExpMapper
    {
        protected override void PostProcess(IEnumerable<CharacterExpBase> loadedElementList)
        {
            foreach (var r in loadedElementList)
            {
                Debug.Log(r);
            }
        }
    }
}