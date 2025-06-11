using UnityEngine;
using UnityEngine.AI;

namespace alpoLib.Sample.Character
{
    public class Kitty : EnemyBase
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
    }
}