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

    WaitForSeconds _dieCount = new(2);  // 죽고 나서 2초간 대기
}
