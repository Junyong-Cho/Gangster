using System;
using static AnimeParams;

partial class PlayerController
{
    public override void GetDamage(int damage)                    // 데미지 입음
    {
        _damage = true;
        animator.SetTrigger(Damage);
        
        _hp = Math.Max(0, _hp - damage);              // 최소 체력은 0

        hpBar.value = _hp / _maxHp;

        if (_hp == 0)                                // hp가 0이면 죽음
            _die();
    }

}
