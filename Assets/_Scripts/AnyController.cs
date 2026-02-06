using UnityEngine;
using UnityEngine.UI;

public abstract class AnyController : MonoBehaviour
{
    protected int _attackPower = 10;                // 공격력
    protected bool _damage = false;                 // 데미지 입음
    protected bool _dead = false;                   // 사망
    protected float _maxHp = 100f;                  // 최대 체력
    protected float _hp = 100f;                     // 체력
    protected bool _onAir = false;                  // 공중에 떠있는지 여부
    protected float preVelocityY = 0;               // 이전 프레임에 중력이 어디 방향으로 작동했는지 여부
    protected bool _whileAttack;

    [SerializeField]
    protected Rigidbody2D rgBody;                   // 리지드바디
    [SerializeField]
    protected Animator animator;                    // 애니메이터
    [SerializeField]                                
    protected Slider hpBar;                         // 체력 바
    [SerializeField]
    protected Transform attackPoint;                // 공격 위치


    public abstract void GetDamage(int damage);     // 데미지 입음
    public virtual void DamageQuit() => _damage = false;    // 데미지 애니메이션 탈출

    public virtual void AttackQuit() => _whileAttack = false;

    protected abstract void _attack();              // 공격

    protected virtual void _flip(Vector2 dir)
    {
        dir.x *= -1;
        transform.localScale = dir;
        hpBar.transform.localScale = dir;           // 체력 바는 반전 X
    }

    protected virtual void _setAnimation(Vector2 move)
    {
        if (_dead) return;

        if (move.x < 0)                                 // 좌우 반전
        {
            Vector2 dir = transform.localScale;

            if (dir.x > 0)
            {
                _flip(dir);
            }
        }
        else if (move.x > 0)
        {
            Vector2 dir = transform.localScale;

            if (dir.x < 0)
            {
                _flip(dir);
            }
        }
    }

    protected virtual void FixedUpdate()                      // 공중에 있는지 측정
    {
        float t = Mathf.Abs(rgBody.linearVelocityY);

        if (t < 0.0001f)
            _onAir = preVelocityY > 0.001f;
        else
            _onAir = true;

        preVelocityY = t;
    }

}
