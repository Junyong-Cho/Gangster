using static AnimeParams;

using System;
using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    void _getSlow()                         // 데미지 또는 장전시 느려짐
    {
        _speed = _jumpPower = 2f;
    }

    void _restoreSpeed()                    // 원래대로 돌아옴
    {
        _speed = _jumpPower = 5f;
    }

    void _action(Action action)             // 움직이면 딴짓 시간 재시작
    {
        _idleTimer.Reset();
        _attacking = false;
        action();
        _idleTimer.Start();
    }

    IEnumerator _attack()                   // 버튼 누르고 있는 동안 공격
    {
        while (input.Player.Attack.IsPressed())
        {
            if (_moveVec == Vector2.zero && !_onAir && !_reloading)
                _attacking = true;
            yield return null;
        }
    }

    void _jump()                            // 바닥에 있어야 점프
    {
        if (!_onAir)
        {
            rgBody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    void _reload()                  // 장전 시작
    {
        _getSlow();
        _reloading = true;
    }

    public void _reloadQuit()       // 장전 끝
    {
        _restoreSpeed();
        _reloading = false;
    }

    void _setAnimation()
    {
        if(_damaged)
            animator.SetTrigger(Damage);
        if(_reloading)
            animator.SetTrigger(Reload);
        animator.SetInteger(IdleTime, (int)(_idleTimer.ElapsedMilliseconds / 1000));
        animator.SetBool(Run, _moveVec != Vector2.zero);
        animator.SetBool(Jump, _onAir);
        animator.SetBool(Shot, _attacking);
    }
}
