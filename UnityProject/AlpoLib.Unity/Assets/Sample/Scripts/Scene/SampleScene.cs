using System;
using alpoLib.UI.Scene;

namespace alpoLib.Sample
{
    [SceneDefine]
    public class SampleScene : SceneBaseWithUI<SampleSceneUI>
    {
        protected override void OnAwake()
        {
            alpoLib.Core.Module.Initialize();
            alpoLib.Data.Module.Initialize(new alpoLib.Data.DataModuleInitParam());

            _ = SceneManager.Initialize(this);
        }

        public override void OnOpen()
        {
            base.OnOpen();
            _ = alpoLib.Data.Module.LoadTableAsync();
        }
    }
}