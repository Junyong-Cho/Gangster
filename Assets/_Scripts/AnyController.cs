using UnityEngine;
using UnityEngine.UI;

public abstract class AnyController : MonoBehaviour
{
    protected bool _damage = false;                 // 데미지 입음
    protected bool _die = false;                    // 사망
    protected float _maxHp = 100f;                  // 최대 체력
    protected float _hp = 100f;                     // 체력

    [SerializeField]
    protected SpriteRenderer flipRenderer;          // 좌우 반전
    [SerializeField]
    protected Rigidbody2D rgBody;                   // 리지드바디
    [SerializeField]
    protected Animator animator;                    // 애니메이터
    [SerializeField]                                
    protected Slider hpBar;                         // 체력 바

    public abstract void GetDamage(int damage);     // 데미지 입음
    public virtual void DamageQuit() => _damage = false;    // 데미지 애니메이션 탈출

    protected abstract void _attack();              // 공격
}
