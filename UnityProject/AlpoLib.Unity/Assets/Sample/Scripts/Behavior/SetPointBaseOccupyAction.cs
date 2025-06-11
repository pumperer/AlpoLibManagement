using System;
using alpoLib.Sample.Platform;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

namespace alpoLib.Sample.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "SetPointBaseOccupy", story: "지정된 [CurrentPointBase] 에서 [TargetPosition] 으로 위치를 지정합니다.",
        category: "Action", id: "526239fc492820bfe314deb4031157d1")]
    public partial class SetPointBaseOccupyAction : Action
    {
        [SerializeReference] public BlackboardVariable<PointBase> CurrentPointBase;
        [SerializeReference] public BlackboardVariable<Vector3> TargetPosition;

        protected override Status OnStart()
        {
            if (!CurrentPointBase.Value)
                return Status.Failure;

            if (!NavMesh.SamplePosition(CurrentPointBase.Value.TargetPoint.position, out var hit, 100f,
                    NavMesh.AllAreas))
            {
                CurrentPointBase.Value = null;
                return Status.Failure;
            }

            CurrentPointBase.Value.Occupied = true;
            TargetPosition.Value = hit.position;
            return Status.Success;
        }
    }
}