using UnityEngine;

public class IdleAction : ActionBase
{
    public IdleAction(ActionContext actionContext) : base(actionContext)
    {
    }

    public override string ActionName => "Idle";

    public override void UpdateAction(float deltaTime)
    {
    }
}
