using System;
using static AnimeParams;

using UnityEngine;

partial class PlayerController
{
    public override void GetDamage(int damage)                    // 데미지 입음
    {
        _damage = true;
        animator.SetTrigger(Damage);
        
        _hp -= damage;

        if (_hp <= 0)                                // hp가 0이면 죽음
        {
            _die();
        }
        hpBar.value = _hp / _maxHp;
    }

    protected override void _setAnimation(Vector2 move)
    {
        base._setAnimation(move);

        animator.SetInteger(IdleTime, (int)(_idleTimer.ElapsedMilliseconds / 1000));
        animator.SetBool(Move, move != Vector2.zero);
        animator.SetBool(Jump, _onAir);
    }
}
