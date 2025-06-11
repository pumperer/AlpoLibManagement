using System;
using UnityEngine;

public class AttackAction : ActionBase
{
    public AttackAction(ActionContext actionContext) : base(actionContext)
    {
    }

    public override string ActionName => "Attack";
}
