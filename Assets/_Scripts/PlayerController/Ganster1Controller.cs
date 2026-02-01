using static AnimeParams;

using UnityEngine;

class Ganster1Controller : PlayerController
{
    [SerializeField]
    Transform Gun;
    [SerializeField]
    GameObject Bullet;

    bool _reloading = false;            // 재장전 여부

    protected override void Awake()
    {
        base.Awake();
        input.Ganster1.Reload.performed += context => _action(_reload);
    }

    protected override void Update()
    {
        _speed = (_damaging || _reloading) ? 2f : 5f;
        transform.Translate(_moveVec * _speed * Time.deltaTime); // 이동
        _setAnimation();
    }

    void _reload()                  // 장전 시작
    {
        if (_damaging || _reloading) return;
        _reloading = true;
        animator.SetTrigger(Reload);
    }

    public void ReloadQuit() => _reloading = false; // 장전 끝

    protected override void _setAnimation()
    {
        base._setAnimation();
        animator.SetBool(Attack, _attacking);
    }
}
