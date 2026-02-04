using UnityEngine;

public partial class ZombieController : AnyController
{
    void Start()
    {
        hpBar.value = 1;
    }

    void Update()
    {
        // 데미지 입거나 죽으면 속도 0
        Vector2 move = _damage || _dead ? Vector2.zero : 
            _moveVector(PlayerTrackerSingleton.GetPlayer().transform.position, transform.position);

        move.Normalize();

        transform.Translate(move * Time.deltaTime * _speed);

        _setAnimation(move);
    }
}
