using alpoLib.Sample.UI;
using alpoLib.UI.Scene;
using UnityEngine;

namespace alpoLib.Sample.Scene
{
    [SceneDefine("Addr/Scenes/TitleScene.unity", SceneResourceType.Addressable)]
    public class TitleScene : SceneBase, ILoadingProgressChangeListener
    {
        [SerializeField] private UIProgressComp loadingProgressComp;
        
        private LoadingTaskMachine _loadingTaskMachine;
        
        public override void OnOpen()
        {
            LoadSequence();
        }
        
        private void LoadSequence()
        {
            _loadingTaskMachine = new LoadingTaskMachine(this);
            _loadingTaskMachine.ClearState();
            _loadingTaskMachine.AddState(new LoadingTaskHello());
            _loadingTaskMachine.AddState(new LoadingTaskLoadTableData());
            _loadingTaskMachine.AddState(new LoadingTaskLoadUserData());
            _loadingTaskMachine.AddState(new LoadingTaskLoadScene());
            _loadingTaskMachine.DoNextState();
        }

        public void OnLoadingProgressChanged(LoadingTaskBase task)
        {
            loadingProgressComp.SetProgress(task.Progress);
            loadingProgressComp.SetText(task.ProgressMessage);
        }
    }
}