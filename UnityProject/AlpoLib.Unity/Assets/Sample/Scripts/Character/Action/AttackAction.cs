using System;
using UnityEngine;

namespace alpoLib.Sample.Character
{
    public class AttackAction : ActionBase
    {
        public AttackAction(ActionContext actionContext) : base(actionContext)
        {
        }

        public override string ActionName => "Attack";
    }
}