using System;
using alpoLib.Sample.Character;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

namespace alpoLib.Sample.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(
        name: "Set Animator State",
        story: "애니메이터의 상태를 [State] 로 변경합니다.",
        category: "Action/Animation",
        id: "7f25c177c30f286f09699d599b99d565")]
    public partial class SetAnimatorStateAction : Action
    {
        [SerializeReference] public BlackboardVariable<AnimatorState> State;

        protected override Status OnStart()
        {
            var kitty = GameObject.GetComponent<Kitty>();
            if (!kitty)
                return Status.Failure;
            kitty.SetState(State.Value);
            return Status.Success;
        }
    }
}