using System;
using System.Diagnostics;

namespace alpoLib.Sample
{
    public class TableLoadSceneUI : SceneUIWithDebugLogLabel
    {
        public async void OnClickLoadTable()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                await alpoLib.Data.Module.LoadTableAsync();
                sw.Stop();
                AppendDebugText("Table Loaded. : " + sw.ElapsedMilliseconds + " ms");

                var p = MessagePopup.CreateMessagePopup("Load Table Completed", "Ok");
                p.Open();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}