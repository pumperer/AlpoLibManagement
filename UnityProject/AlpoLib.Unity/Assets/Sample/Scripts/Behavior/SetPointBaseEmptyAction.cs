using System;
using alpoLib.Sample.Platform;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

namespace alpoLib.Sample.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "SetPointBaseEmpty", story: "[CurrentPointBase] 를 비웁니다.", category: "Action",
        id: "0dc339f349beedd44c82a4255f8ac258")]
    public partial class SetPointBaseEmptyAction : Action
    {
        [SerializeReference] public BlackboardVariable<PointBase> CurrentPointBase;

        protected override Status OnStart()
        {
            if (!CurrentPointBase.Value)
                return Status.Success;

            CurrentPointBase.Value.Occupied = false;
            CurrentPointBase.Value = null;

            return Status.Success;
        }
    }
}