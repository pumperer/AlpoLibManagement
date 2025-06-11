using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindRandomPositionInNavMesh", story: "[Self] 가 이동할 수 있는 랜덤 위치를 찾아 [TargetPosition] 에 지정합니다.", category: "Action", id: "6747dd2665d5a2e120007a4dc9d9fae0")]
public partial class FindRandomPositionInNavMeshAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Vector3> TargetPosition;
    protected override Status OnStart()
    {
        var success = MoveRandomPosition(10);
        return success ? Status.Success : Status.Failure;
    }
    
    public bool MoveRandomPosition(float radius)
    {
        var randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0;
        var position = Self.Value.transform.position + randomDirection;
        position.y = 0;
        if (!NavMesh.SamplePosition(position, out var hit, 100f, NavMesh.AllAreas))
            return false;
        
        TargetPosition.Value = hit.position;
        return true;

    }
}

