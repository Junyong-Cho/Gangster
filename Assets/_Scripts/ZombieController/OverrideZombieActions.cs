using static AnimeParams;

partial class ZombieController
{
    protected override void _attack()
    {
        
    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            hpBar.value = 0;
            animator.SetTrigger(Die);
            Destroy(gameObject, 2);
        }

        _damage = true;

        hpBar.value = _hp / _maxHp;

        animator.SetTrigger(Damage);
    }

}
