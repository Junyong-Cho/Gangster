using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

partial class PlayerController
{
    protected float maxHp = 100f;                   // 최대 체력
    protected float hp = 100f;                      // 체력
    protected float _speed = 5f;                    // 이동 속도
    protected float _jumpPower = 5f;                // 점프력
    protected bool _onAir = false;                  // 공중에 떠있는지 여부
    protected bool _attacking = false;              // 공격중 여부
    protected bool _canAttack = true;               // 공격 가능 여부 (공격 속도에 영향)
    protected bool _damaging = false;               // 데미지 여부
    protected bool _alive = true;                   // 살아있는지 여부

    protected Stopwatch _idleTimer;                 // 특정 시간동안 가만히 있으면 딴짓함

    protected Vector2 _moveVec;                     // 움직임
    protected InputSystem_Actions input;            // 인풋시스템

    [SerializeField]
    protected Animator animator;                    // 애니메이터

    [SerializeField]
    protected SpriteRenderer flipRender;            // 좌우 반전
    [SerializeField]
    protected Rigidbody2D rgBody;                   // 리지드바디

    [Header("Ground Check")]
    [SerializeField]
    protected LayerMask groundLayer;                // 바닥 옵젝 태그

    [SerializeField]
    protected Transform Feet;                       // 발 위치

    [SerializeField]                                // 체력 바
    protected Slider hpBar;

    protected WaitForSeconds _attackSpeed = new(1.5f);    // 공격 속도
}
