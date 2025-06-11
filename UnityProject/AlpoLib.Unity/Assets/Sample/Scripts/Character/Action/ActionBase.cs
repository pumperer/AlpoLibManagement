using UnityEngine;

public abstract class ActionBase
{
    public abstract string ActionName { get; }
    
    protected void OnActionStart()
    {
    }

    protected void OnActionEnd()
    {
    }

    protected void OnActionCancel()
    {
    }

    public virtual void StartAction()
    {
        
    }
    
    public virtual void CancelAction()
    {
    }
}
