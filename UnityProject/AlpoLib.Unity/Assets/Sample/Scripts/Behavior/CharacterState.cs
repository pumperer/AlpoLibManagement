using Unity.Behavior;

namespace alpoLib.Sample.Behavior
{
    [BlackboardEnum]
    public enum CharacterState
    {
        Idle,
        Move,
        Attack,
        Bread,
        Wander,
        TargetMove,
        PositionMove,
    }
    
    [BlackboardEnum]
    public enum AnimatorState
    {
        Idle,
        Move,
        Run,
        Bread,
    }

    [BlackboardEnum]
    public enum ActionState
    {
        Idle,
        Attack,
    }
}