using static Tags;

using System.Diagnostics;
using UnityEngine;

public partial class PlayerController : AnyController
{
    protected virtual void Awake()
    {
        input = new();                                                          // 인풋시스템 생성
        _idleTimer = Stopwatch.StartNew();                                      // 딴짓 시간 측정 시작

        input.Player.Move.performed += context => _action(() =>                 // 움직임
        {
            _moveVec = context.ReadValue<Vector2>();
        });

        input.Player.Move.canceled += context => _moveVec = Vector2.zero;       // 움직임 멈춤

        input.Player.Attack.performed += context => _action(_attack);           // 공격

        input.Player.Attack.canceled += context => _attacking = false;          // 공격 중지

        input.Player.Jump.performed += context => _action(_jump);               // 점프

        hpBar.value = 1;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(HealItem))
        {
            _hp = Mathf.Min(_maxHp, _hp + 30);
            hpBar.value = _hp / _maxHp;

            ObjectPoolSingletons.HealItemPool.Release(collision.gameObject.transform.parent.gameObject);
        }
    }

    protected virtual void OnEnable()             
    {
        input.Enable();    
    }
                                            // 인풋시스템 온오프
    protected virtual void OnDisable()
    {
        input.Disable();    
    }

    protected virtual void Update()
    {
        if (_dead) return;
        _setSpeed();

        transform.Translate(_moveVec * _speed * Time.deltaTime); // 이동
        _setAnimation(_moveVec);
    }
}
