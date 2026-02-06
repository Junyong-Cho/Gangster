using UnityEngine;
using static AnimeParams;

partial class ZombieController
{
    protected override void _attack()
    {
        _whileAttack = true;
        animator.SetTrigger(Attack);
    }

    void _onAttack()
    {
        var collider = Physics2D.OverlapCircle(attackPoint.position, _attackRange, PlayerLayer);

        if (collider == null)
            return;

        PlayerController player = collider.GetComponent<PlayerController>();

        player.GetDamage(_attackPower);
    }

    public override void GetDamage(int damage)
    {
        if (_dead) 
            return;

        _hp -= damage;

        if (_hp <= 0)
        {
            hpBar.value = 0;
            _dead = true;
            animator.SetTrigger(Die);
            Destroy(gameObject, 2);
        }

        _damage = true;

        hpBar.value = _hp / _maxHp;

        animator.SetTrigger(Damage);
    }
    protected override void _setAnimation(Vector2 move)
    {
        base._setAnimation(move);

        animator.SetBool(Move, move != Vector2.zero);
    }

}
