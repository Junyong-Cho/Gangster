using UnityEngine;
using UnityEngine.AI;

partial class ZombieController
{
    static float _speed = 1f;

    [SerializeField]
    LayerMask PlayerLayer;
    float _attackRange = 0.5f;

    [SerializeField]
    NavMeshAgent agent;
}
