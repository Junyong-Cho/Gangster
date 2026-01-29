using static Tags;

using System.Diagnostics;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        input = new();                                                          // 인풋시스템 생성
        _idleTimer = Stopwatch.StartNew();                                      // 딴짓 시간 측정 시작
        animator = GetComponent<Animator>();                                    // 애니메이터 가져오기

        input.Player.Move.performed += context => _action(() =>                 // 움직임
        {
            _moveVec = context.ReadValue<Vector2>();
        });

        input.Player.Move.canceled += context => _moveVec = Vector2.zero;       // 움직임 멈춤

        input.Player.Attack.performed += context => StartCoroutine(_attack());  // 공격

        input.Player.Attack.canceled += context => _attacking = false;          // 공격 중지

        input.Player.Jump.performed += context => _action(_jump);               // 점프

        input.Player.Reload.performed += context => _action(_reload);
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
        if (collision.CompareTag(Dam))
        {

        }
    }

    

    void Update()
    {
        if (_moveVec.x < 0)                 // 좌우 반전
            flipRender.flipX = true;
        else if (_moveVec.x > 0)
            flipRender.flipX = false;

        transform.Translate(_moveVec * _speed * Time.deltaTime); // 이동
        _setAnimation();                    // 애니메이션 설정
    }

    void FixedUpdate()                      // 공중에 있는지 측정
    {
        var hit = Physics2D.Raycast(Feet.position, Vector2.down, 0.1f, groundLayer);

        _onAir = hit.collider == null;
    }

}
