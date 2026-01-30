using static Tags;

using System.Diagnostics;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        input = new();                                                          // 인풋시스템 생성
        _idleTimer = Stopwatch.StartNew();                                      // 딴짓 시간 측정 시작

        input.Player.Move.performed += context => _action(() =>                 // 움직임
        {
            _moveVec = context.ReadValue<Vector2>();
        });

        input.Player.Move.canceled += context => _moveVec = Vector2.zero;       // 움직임 멈춤

        input.Player.Attack.performed += context => StartCoroutine(_attack());  // 공격

        input.Player.Attack.canceled += context => _attacking = false;          // 공격 중지

        input.Player.Jump.performed += context => _action(_jump);               // 점프

        input.Player.Reload.performed += context => _action(_reload);

        hpBar.value = 1;
    }

    void OnEnable()             
    {
        input.Enable();    
    }
                                // 인풋시스템 온오프
    void OnDisable()
    {
        input.Disable();    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("임시 값"))
        {
            _getDamgage(10);
        }
    }
    
    void Update()
    {

        _speed = (_reloading || _damaging) ? 2f : 5f;

        transform.Translate(_moveVec * _speed * Time.deltaTime); // 이동
        _setAnimation();
    }

    void FixedUpdate()                      // 공중에 있는지 측정
    {
        var hit = Physics2D.Raycast(Feet.position, Vector2.down, 0.1f, groundLayer);

        _onAir = hit.collider == null;
    }

}
