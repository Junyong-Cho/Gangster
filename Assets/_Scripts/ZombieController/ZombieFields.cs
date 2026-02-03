using UnityEngine;

partial class ZombieController
{
    static float _speed = 1f;

    [SerializeField]
    LayerMask PlayerLayer;
    float _attackRange = 0.5f;
}
