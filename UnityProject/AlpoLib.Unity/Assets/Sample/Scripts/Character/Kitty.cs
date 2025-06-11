using UnityEngine;
using UnityEngine.AI;

namespace alpoLib.Sample.Character
{
    public class Kitty : CharacterBase
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
    }
}