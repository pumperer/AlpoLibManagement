using alpoLib.UI.Scene;
using alpoLib.Util;
using UnityEngine;

namespace alpoLib.Sample
{
    [SceneDefine]
    public class StartupScene : SceneBase
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            Core.Module.Initialize();
            CoroutineTaskManager.Init(true);
            TaskScheduler.Init(true);
            _ = SceneManager.Initialize(this);
        }

        public override void OnOpen()
        {
            base.OnOpen();
            OpenNextScene();
        }

        private void OpenNextScene()
        {
            _ = SceneManager.Instance.OpenSceneAsync<TableLoadScene>();
        }
    }
}