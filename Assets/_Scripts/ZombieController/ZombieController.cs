using UnityEngine;

public partial class ZombieController : AnyController
{

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.updatePosition = false;
    }

    void OnEnable()
    {
        hpBar.value = 1;
        _hp = _maxHp;

        _dead = false;

        animator.Rebind();
    }

    void Update()
    {
        Vector2 move = Vector2.zero;

        Vector2 player = PlayerTrackerSingleton.PlayerPostion;

        if (!_damage && !_dead && !_whileAttack)
        {
            if(Vector2.Distance(transform.position, player) < 1f)
            {
                _attack();
            }
            else
            {
                agent.SetDestination(player);
                agent.nextPosition = transform.position;

                move = (agent.steeringTarget - transform.position).normalized;
            }
        }

        transform.Translate(move * Time.deltaTime * _speed);

        _setAnimation(move);
    }
}
