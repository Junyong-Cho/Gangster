using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

partial class PlayerController
{
    float maxHp = 100f;                 // 최대 체력
    float hp = 100f;                    // 체력
    float _speed = 5f;                  // 이동 속도
    float _jumpPower = 5f;              // 점프력
    bool _onAir = false;                // 공중에 떠있는지 여부
    bool _attacking = false;            // 공격중 여부
    bool _reloading = false;            // 재장전 여부
    bool _damaging = false;              // 데미지 여부
    bool _alive = true;
    Stopwatch _idleTimer;               // 특정 시간동안 가만히 있으면 딴짓함

    Vector2 _moveVec;                   // 움직임
    InputSystem_Actions input;          // 인풋시스템

    [SerializeField]
    Animator animator;                  // 애니메이터

    [SerializeField]
    SpriteRenderer flipRender;          // 좌우 반전
    [SerializeField]
    Rigidbody2D rgBody;                 // 리지드바디

    [Header("Ground Check")]
    [SerializeField]
    LayerMask groundLayer;              // 바닥 옵젝 태그

    [SerializeField]
    Transform Feet;                     // 발 위치

    [SerializeField]
    Slider hpBar;
}
