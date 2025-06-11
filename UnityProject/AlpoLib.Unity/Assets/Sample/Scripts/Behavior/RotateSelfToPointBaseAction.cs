using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateSelfToPointBase", story: "[Self] 의 방향을 [CurrentPointBase] 와 같을 방향으로 맞춥니다.", category: "Action", id: "3904baa3fb88b6b7d1b172f4a954002a")]
public partial class RotateSelfToPointBaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<PointBase> CurrentPointBase;

    private Quaternion _startRotation;
    private Quaternion _targetRotation;
    private float _duration = 0.5f;
    private float _currentTime;
    
    protected override Status OnStart()
    {
        if (!CurrentPointBase.Value)
            return Status.Success;
        _startRotation = Self.Value.transform.localRotation;
        _targetRotation = CurrentPointBase.Value.transform.localRotation;
        _currentTime = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var t = _currentTime / _duration;
        var r = Quaternion.Lerp(_startRotation, _targetRotation, t);
        Self.Value.transform.localRotation = r;
        _currentTime += Time.deltaTime;
        return _currentTime >= _duration ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
        Self.Value.transform.localRotation = _targetRotation;
    }
}

