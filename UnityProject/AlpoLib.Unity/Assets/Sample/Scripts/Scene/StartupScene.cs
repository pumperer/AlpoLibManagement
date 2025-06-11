using alpoLib.UI.Scene;
using alpoLib.Util;
using UnityEngine;

namespace alpoLib.Sample.Scene
{
    [SceneDefine]
    public class StartupScene : SceneBase
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            alpoLib.Core.Module.Initialize();
            alpoLib.Data.Module.Initialize(new alpoLib.Data.DataModuleInitParam());
            CoroutineTaskManager.Init(true);
            TaskScheduler.Init(true);
            _ = SceneManager.Initialize(this);
        }

        public override void OnOpen()
        {
            _ = SceneManager.Instance.OpenSceneAsync<TitleScene>();
        }
    }
}