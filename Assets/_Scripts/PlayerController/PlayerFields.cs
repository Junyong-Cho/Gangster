using System.Diagnostics;
using UnityEngine;

partial class PlayerController
{
    float speed = 5f;                   // 이동 속도
    float jump = 5f;                    // 점프력
    bool _onAir = false;                // 공중에 떠있는지 여부
    bool _attacking = false;            // 공격중 여부
    Stopwatch _idleTimer;               // 특정 시간동안 가만히 있으면 딴짓함

    Animator animator;                  // 애니메이터
    Vector2 _moveVec;                   // 움직임
    InputSystem_Actions input;          // 인풋시스템

    [SerializeField]
    SpriteRenderer flipRender;          // 좌우 반전
    [SerializeField]
    Rigidbody2D rgBody;                 // 리지드바디

    [Header("Ground Check")]
    [SerializeField]
    LayerMask groundLayer;              // 바닥 옵젝 태그

    [SerializeField]
    Transform Feet;                     // 발 위치
}
