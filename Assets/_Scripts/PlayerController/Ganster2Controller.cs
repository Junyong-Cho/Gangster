using UnityEngine;
using static AnimeParams;

public class Ganster2Controller : PlayerController
{
    [SerializeField]
    LayerMask enemyLayers;              // 적 레이어
    float _attackRange;                 // 주먹 원 반경

    Collider2D[] hitEnemy;              // 맞는 적

    ContactFilter2D contactFilter;

    void Start()
    {
        hitEnemy = new Collider2D[10];  // 최대 10명만 때릴 것

        contactFilter = new();

        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(enemyLayers);    // enemyLayer만 감지
        contactFilter.useLayerMask = true;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag(Tags.Player))
    //    {
    //        GetDamage(10);
    //    }
    //}

    protected override void _attack()
    {
        animator.SetTrigger(Attack);
    }

    void _onJab()       // 주먹이 닿는 범위에 있는 최대 10명의 적 공격
    {
        int enemys = Physics2D.OverlapCircle(attackPoint.position, _attackRange, contactFilter, hitEnemy);

        for(int i = 0; i < enemys; i++)
        {
            int score = hitEnemy[i].GetComponent<ZombieController>().GetDamage(_attackPower);

            AddScore(score);
        }
    }

    void _uppercut()
    {
        int enemys = Physics2D.OverlapCircle(attackPoint.position, _attackRange, contactFilter, hitEnemy);

        for(int i = 0; i < enemys; i++)
        {
            Vector2 dir = Vector2.up;

            if (transform.localScale.x < 0)
            {
                dir += Vector2.left;
            }
            else
            {
                dir += Vector2.right;
            }

            dir.Normalize();

            int score = hitEnemy[i].GetComponent<ZombieController>().GetUppercut(dir * 2f, _attackPower * 2);

            AddScore(score);
        }
    }

    protected override void _setSpeed()
    {
        if (_attacking)
            _speed = 0;
        else if (_damage)
            _speed = 2f;
        else
            _speed = 5f;
    }

}
