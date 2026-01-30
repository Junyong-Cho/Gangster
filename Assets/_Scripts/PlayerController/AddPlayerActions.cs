using static AnimeParams;

using System;
using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    void _action(Action action)             // 움직이면 딴짓 시간 재시작
    {
        _idleTimer.Reset();
        _attacking = false;
        action();
        _idleTimer.Start();
    }

    void _getDamgage(int damage)                    // 데미지 입음
    {
        _damaging = true;
        animator.SetTrigger(Damage);

        hp = Math.Max(0, hp - damage);              // 최소 체력은 0

        hpBar.value = hp / maxHp;

        if (hp == 0)                                // hp가 0이면 죽음
            _die();
    }

    public void DamageQuit() => _damaging = false;   // 데미지 애니메이션 탈출

    void _die()
    {
        _alive = false;
        _speed = 0f;
        _jumpPower = 0f;
        animator.SetTrigger(Die);
    }

    IEnumerator _attack()                   // 버튼 누르고 있는 동안 공격
    {
        while (input.Player.Attack.IsPressed())
        {
            if (_moveVec == Vector2.zero && !_onAir && !_reloading && !_damaging)
                _attacking = true;
            else
                _attacking = false;
            yield return null;
        }
    }

    void _jump()                            // 바닥에 있어야 점프
    {
        if (!_onAir)
        {
            _jumpPower = _speed;
            rgBody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    void _reload()                  // 장전 시작
    {
        if (_damaging || _reloading) return;
        _reloading = true;
        animator.SetTrigger(Reload);
    }

    public void ReloadQuit() => _reloading = false; // 장전 끝

    void _setAnimation()
    {
        if (!_alive) return;

        if (_moveVec.x < 0)                 // 좌우 반전
            flipRender.flipX = true;
        else if (_moveVec.x > 0)
            flipRender.flipX = false;

        animator.SetInteger(IdleTime, (int)(_idleTimer.ElapsedMilliseconds / 1000));
        animator.SetBool(Move, _moveVec != Vector2.zero);
        animator.SetBool(Jump, _onAir);
        animator.SetBool(Shot, _attacking);
    }
}
