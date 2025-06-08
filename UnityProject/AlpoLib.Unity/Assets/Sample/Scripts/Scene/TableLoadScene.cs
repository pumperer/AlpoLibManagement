using System;
using alpoLib.UI.Scene;
using UnityEngine;

namespace alpoLib.Sample
{
    [SceneDefine("Addr/Scenes/TableLoadScene.unity", SceneResourceType.Addressable)]
    public class TableLoadScene : SceneBaseWithUI<TableLoadSceneUI>
    {
        public override void OnOpen()
        {
            base.OnOpen();
            alpoLib.Data.Module.Initialize(new alpoLib.Data.DataModuleInitParam());
        }
    }
}