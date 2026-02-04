using System;
using UnityEngine;
using static AnimeParams;

public partial class PlayerController
{
    protected virtual void _action(Action action)             // 움직이면 딴짓 시간 재시작
    {
        if (_dead)
            return;
        _idleTimer.Reset();
        _attacking = false;
        action();
        _idleTimer.Start();
    }

    protected virtual void _die()
    {
        _dead = true;
        _speed = 0f;
        animator.SetTrigger(Die);
    }

    protected override void _attack()
    {
        //StartCoroutine(_attackMotion());
    }

    protected virtual void _jump()                            // 바닥에 있어야 점프
    {
        if (!_onAir)
        {
            rgBody.AddForce(Vector2.up * _speed /* 점프력 == 스피드 */ , ForceMode2D.Impulse);
        }
    }

    protected virtual void _setSpeed()
    {
        _speed = _damage ? 2f : 5f;
    }
}

//IEnumerator _attackMotion()                   // 버튼 누르고 있는 동안 공격
//{
//    var cor = StartCoroutine(_shoot());

//    while (input.Player.Attack.IsPressed())
//    {
//        if (_moveVec == Vector2.zero && !_onAir && !_reloading && !_damaging)
//        {
//            _attacking = true;

//        }
//        else
//        {
//            _attacking = false;

//        }
//        yield return null;
//    }
//}

//IEnumerator _shoot()
//{
//    while (_attacking)
//    {
//        Instantiate(Bullet, Gun.position, Quaternion.identity);
//        yield return _attackSpeed;
//    }
//}
