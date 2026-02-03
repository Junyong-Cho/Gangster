using System.Diagnostics;
using UnityEngine;

partial class PlayerController
{
    protected float _speed = 5f;                    // 이동 속도
    protected int _attackPower = 10;                // 공격력
    protected float _jumpPower = 5f;                // 점프력
    protected bool _attacking = false;              // 공격중 여부
  //protected bool _canAttack = true;               // 공격 가능 여부 (공격 속도에 영향)

    protected Stopwatch _idleTimer;                 // 특정 시간동안 가만히 있으면 딴짓함

    protected Vector2 _moveVec;                     // 움직임
    protected InputSystem_Actions input;            // 인풋시스템

    protected WaitForSeconds _attackSpeed = new(1.5f);    // 공격 속도
}
