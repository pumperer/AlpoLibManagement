using System;
using System.Drawing;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindBreadPoint", story: "[Self] 가 이동할 수 있는 랜덤한 빵굽는 위치를 찾아 [CurrentPointBase] 에 지정합니다.", category: "Action", id: "5b2912a1f5acb1a39bfdf7a275a1a675")]
public partial class FindBreadPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<PointBase> CurrentPointBase;
    protected override Status OnStart()
    {
        if (!PointHolder.Instance.TryGetPoint(typeof(BreadPoint), out var pointBase))
            return Status.Failure;
        CurrentPointBase.Value = pointBase;
        return Status.Success;
    }
}

